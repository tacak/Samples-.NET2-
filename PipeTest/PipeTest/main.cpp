#include <windows.h>

#define R 0
#define W 1

#define CHR_BUF 4048

int WINAPI WinMain(  HINSTANCE hInst,  HINSTANCE hPrevInst,  LPSTR lpCmdLine,  int nCmdShow)         
{

	HANDLE hPipeP2C[2];  // 親 → 子 のパイプ(stdin)
	HANDLE hPipeC2P[2];  // 子 → 親 のパイプ(stdout)
	HANDLE hPipeC2PE[2]; // 子 → 親 のパイプ(stderr)
	HANDLE hDupPipeP2CW; // 親 → 子 のパイプ(stdin)の複製
	HANDLE hDupPipeC2PR; // 子 → 親 のパイプ(stdout)の複製
	HANDLE hDupPipeC2PE; // 子 → 親 のパイプ(stderr)の複製

	SECURITY_ATTRIBUTES secAtt;
	STARTUPINFO startInfo;
	PROCESS_INFORMATION proInfo;

	HANDLE hParent = GetCurrentProcess();

	char str[CHR_BUF],processName[CHR_BUF];
	DWORD dwByte;

	// コンソール割り当て
	FreeConsole();
	AllocConsole();

	//------------------------------------------------------
	// パイプ作成(STDOUT,STDERR,STDIN の３本)

	// 親の STDOUT , STDIN ,STDERR のハンドルを保存
	HANDLE hOldIn = GetStdHandle(STD_INPUT_HANDLE);
	HANDLE hOldOut = GetStdHandle(STD_OUTPUT_HANDLE);
	HANDLE hOldErr = GetStdHandle(STD_ERROR_HANDLE);

	// SECURITY_ATTRIBUTES の設定(パイプを作るのに必要
	secAtt.nLength = sizeof(SECURITY_ATTRIBUTES);
	secAtt.lpSecurityDescriptor = NULL;
	secAtt.bInheritHandle = TRUE;  // ハンドル継承

	//------------------------------------------------------
	// STDOUT

	// パイプ作成
	CreatePipe(&hPipeC2P[R],&hPipeC2P[W],&secAtt,0);

	// 「子」プロセスの STDOUT をセット
	SetStdHandle(STD_OUTPUT_HANDLE,hPipeC2P[W]);

	// 「子」からくるパイプの読み側(つまり親がリードする側)は継承しない
	DuplicateHandle(hParent,hPipeC2P[R],hParent,&hDupPipeC2PR,0,FALSE,DUPLICATE_SAME_ACCESS);

	// 読み側のハンドルをクローズ
	CloseHandle(hPipeC2P[R]);

	//------------------------------------------------------
	// STDERR

	// パイプ作成
	CreatePipe(&hPipeC2PE[R],&hPipeC2PE[W],&secAtt,0);

	// 「子」プロセスの STDERR をセット
	SetStdHandle(STD_ERROR_HANDLE,hPipeC2PE[W]);

	// 「子」からくるパイプの読み側(つまり親がリードする側)は継承しない
	DuplicateHandle(hParent,hPipeC2PE[R],hParent,&hDupPipeC2PE,0,FALSE,DUPLICATE_SAME_ACCESS);

	// 読み側のハンドルをクローズ
	CloseHandle(hPipeC2PE[R]);

	//------------------------------------------------------
	// STDIN

	//パイプ作成

	CreatePipe(&hPipeP2C[R],&hPipeP2C[W],&secAtt,0); 

	// 「子」プロセスの STDIN をセット
	SetStdHandle(STD_INPUT_HANDLE,hPipeP2C[R]);

	// 「子」からくるパイプの書き込み側(つまり親がライトする側)は継承しない
	DuplicateHandle(hParent,hPipeP2C[W],hParent,&hDupPipeP2CW,0,FALSE,DUPLICATE_SAME_ACCESS);

	// 書き込み側のハンドルをクローズ
	CloseHandle(hPipeP2C[W]);

	// パイプ作成終了
	//------------------------------------------------------


	// STARTUPINFO の設定
	memset(&startInfo,0,sizeof(STARTUPINFO));
	startInfo.cb = sizeof(STARTUPINFO);

	// 子プロセスでコマンドインタープリタを起動
	// STDIN,STDOUT,STDIN のハンドルが継承される(つまり親とパイプでつながる)

	GetEnvironmentVariable("ComSpec",processName,CHR_BUF);

	if(CreateProcess(processName,"",NULL,NULL,TRUE,
		0,NULL,NULL,&startInfo,&proInfo)==TRUE){

			// 子プロセスが起動したら親の STDIN と STDOUT を戻す
			SetStdHandle(STD_OUTPUT_HANDLE,hOldOut);
			SetStdHandle(STD_INPUT_HANDLE,hOldIn);
			SetStdHandle(STD_ERROR_HANDLE,hOldErr);

			// エコーなしで入力して、送信してしもたらええんやないか？


			// "dir" コマンドを子プロセスに送る
			wsprintf(str,"dir\r\n");  // (注) CR-LF を入れないとコマンドを受け取ってくれない
			WriteFile(hDupPipeP2CW,str,strlen(str),&dwByte,NULL);

			// "exit" 
			wsprintf(str,"exit\r\n");  
			WriteFile(hDupPipeP2CW,str,strlen(str),&dwByte,NULL);

			// バッファのフラッシュ
			FlushFileBuffers(hDupPipeP2CW);
			FlushFileBuffers(hDupPipeC2PR);

			// 子プロセスが終るまで停止
			WaitForSingleObject(proInfo.hProcess,INFINITE);

			// 子からきたメッセージを読む
			ReadFile(hDupPipeC2PR,str,CHR_BUF,&dwByte,NULL);
			str[dwByte] = '\0';

			MessageBox(NULL,str,"",NULL);

	}

	return 0;
}
