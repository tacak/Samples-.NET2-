#include <windows.h>

#define R 0
#define W 1

#define CHR_BUF 4048

int WINAPI WinMain(  HINSTANCE hInst,  HINSTANCE hPrevInst,  LPSTR lpCmdLine,  int nCmdShow)         
{

	HANDLE hPipeP2C[2];  // �e �� �q �̃p�C�v(stdin)
	HANDLE hPipeC2P[2];  // �q �� �e �̃p�C�v(stdout)
	HANDLE hPipeC2PE[2]; // �q �� �e �̃p�C�v(stderr)
	HANDLE hDupPipeP2CW; // �e �� �q �̃p�C�v(stdin)�̕���
	HANDLE hDupPipeC2PR; // �q �� �e �̃p�C�v(stdout)�̕���
	HANDLE hDupPipeC2PE; // �q �� �e �̃p�C�v(stderr)�̕���

	SECURITY_ATTRIBUTES secAtt;
	STARTUPINFO startInfo;
	PROCESS_INFORMATION proInfo;

	HANDLE hParent = GetCurrentProcess();

	char str[CHR_BUF],processName[CHR_BUF];
	DWORD dwByte;

	// �R���\�[�����蓖��
	FreeConsole();
	AllocConsole();

	//------------------------------------------------------
	// �p�C�v�쐬(STDOUT,STDERR,STDIN �̂R�{)

	// �e�� STDOUT , STDIN ,STDERR �̃n���h����ۑ�
	HANDLE hOldIn = GetStdHandle(STD_INPUT_HANDLE);
	HANDLE hOldOut = GetStdHandle(STD_OUTPUT_HANDLE);
	HANDLE hOldErr = GetStdHandle(STD_ERROR_HANDLE);

	// SECURITY_ATTRIBUTES �̐ݒ�(�p�C�v�����̂ɕK�v
	secAtt.nLength = sizeof(SECURITY_ATTRIBUTES);
	secAtt.lpSecurityDescriptor = NULL;
	secAtt.bInheritHandle = TRUE;  // �n���h���p��

	//------------------------------------------------------
	// STDOUT

	// �p�C�v�쐬
	CreatePipe(&hPipeC2P[R],&hPipeC2P[W],&secAtt,0);

	// �u�q�v�v���Z�X�� STDOUT ���Z�b�g
	SetStdHandle(STD_OUTPUT_HANDLE,hPipeC2P[W]);

	// �u�q�v���炭��p�C�v�̓ǂݑ�(�܂�e�����[�h���鑤)�͌p�����Ȃ�
	DuplicateHandle(hParent,hPipeC2P[R],hParent,&hDupPipeC2PR,0,FALSE,DUPLICATE_SAME_ACCESS);

	// �ǂݑ��̃n���h�����N���[�Y
	CloseHandle(hPipeC2P[R]);

	//------------------------------------------------------
	// STDERR

	// �p�C�v�쐬
	CreatePipe(&hPipeC2PE[R],&hPipeC2PE[W],&secAtt,0);

	// �u�q�v�v���Z�X�� STDERR ���Z�b�g
	SetStdHandle(STD_ERROR_HANDLE,hPipeC2PE[W]);

	// �u�q�v���炭��p�C�v�̓ǂݑ�(�܂�e�����[�h���鑤)�͌p�����Ȃ�
	DuplicateHandle(hParent,hPipeC2PE[R],hParent,&hDupPipeC2PE,0,FALSE,DUPLICATE_SAME_ACCESS);

	// �ǂݑ��̃n���h�����N���[�Y
	CloseHandle(hPipeC2PE[R]);

	//------------------------------------------------------
	// STDIN

	//�p�C�v�쐬

	CreatePipe(&hPipeP2C[R],&hPipeP2C[W],&secAtt,0); 

	// �u�q�v�v���Z�X�� STDIN ���Z�b�g
	SetStdHandle(STD_INPUT_HANDLE,hPipeP2C[R]);

	// �u�q�v���炭��p�C�v�̏������ݑ�(�܂�e�����C�g���鑤)�͌p�����Ȃ�
	DuplicateHandle(hParent,hPipeP2C[W],hParent,&hDupPipeP2CW,0,FALSE,DUPLICATE_SAME_ACCESS);

	// �������ݑ��̃n���h�����N���[�Y
	CloseHandle(hPipeP2C[W]);

	// �p�C�v�쐬�I��
	//------------------------------------------------------


	// STARTUPINFO �̐ݒ�
	memset(&startInfo,0,sizeof(STARTUPINFO));
	startInfo.cb = sizeof(STARTUPINFO);

	// �q�v���Z�X�ŃR�}���h�C���^�[�v���^���N��
	// STDIN,STDOUT,STDIN �̃n���h�����p�������(�܂�e�ƃp�C�v�łȂ���)

	GetEnvironmentVariable("ComSpec",processName,CHR_BUF);

	if(CreateProcess(processName,"",NULL,NULL,TRUE,
		0,NULL,NULL,&startInfo,&proInfo)==TRUE){

			// �q�v���Z�X���N��������e�� STDIN �� STDOUT ��߂�
			SetStdHandle(STD_OUTPUT_HANDLE,hOldOut);
			SetStdHandle(STD_INPUT_HANDLE,hOldIn);
			SetStdHandle(STD_ERROR_HANDLE,hOldErr);

			// �G�R�[�Ȃ��œ��͂��āA���M���Ă������炦�����Ȃ����H


			// "dir" �R�}���h���q�v���Z�X�ɑ���
			wsprintf(str,"dir\r\n");  // (��) CR-LF �����Ȃ��ƃR�}���h���󂯎���Ă���Ȃ�
			WriteFile(hDupPipeP2CW,str,strlen(str),&dwByte,NULL);

			// "exit" 
			wsprintf(str,"exit\r\n");  
			WriteFile(hDupPipeP2CW,str,strlen(str),&dwByte,NULL);

			// �o�b�t�@�̃t���b�V��
			FlushFileBuffers(hDupPipeP2CW);
			FlushFileBuffers(hDupPipeC2PR);

			// �q�v���Z�X���I��܂Œ�~
			WaitForSingleObject(proInfo.hProcess,INFINITE);

			// �q���炫�����b�Z�[�W��ǂ�
			ReadFile(hDupPipeC2PR,str,CHR_BUF,&dwByte,NULL);
			str[dwByte] = '\0';

			MessageBox(NULL,str,"",NULL);

	}

	return 0;
}
