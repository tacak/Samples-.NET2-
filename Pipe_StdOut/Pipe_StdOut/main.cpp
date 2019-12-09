#include <windows.h>
#include <tchar.h>

int APIENTRY _tWinMain(HINSTANCE, HINSTANCE, LPTSTR, int)
{
    //���O�Ȃ��p�C�v�쐬
    SECURITY_ATTRIBUTES sa = {0};
    sa.lpSecurityDescriptor = NULL;
    sa.nLength = sizeof(SECURITY_ATTRIBUTES);
    sa.bInheritHandle = TRUE;
    HANDLE hRead, hWrite;
    if(!CreatePipe(&hRead, &hWrite, &sa, 0)) {
        return 0;
    }

	HANDLE hRead2, hWrite2;
    if(!CreatePipe(&hRead2, &hWrite2, &sa, 0)) {
        return 0;
    }
    
    //�v���Z�X�쐬
    STARTUPINFO si = {0};
    PROCESS_INFORMATION pi = {0};
    si.cb = sizeof(STARTUPINFO);
    si.dwFlags = STARTF_USESHOWWINDOW | STARTF_USESTDHANDLES;
    si.wShowWindow = SW_SHOWDEFAULT;
    si.hStdOutput = hWrite;
	si.hStdInput = hRead2;
    //ping ���s
    TCHAR szCommandLine[] = TEXT("ping localhost");
    if(CreateProcess(NULL, szCommandLine, NULL, NULL, TRUE, 0, NULL, NULL, &si, &pi)) {
		//WriteFile(hWrite, "192.168.0.18/\n", 15, NULL, NULL);
        WaitForInputIdle(pi.hProcess, INFINITE);
        //�v���Z�X�ҋ@
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hThread);
        CloseHandle(pi.hProcess);
        //�p�C�v���猋�ʂ�ǂݏo��
        DWORD dwAvail;
        if(PeekNamedPipe(hRead, NULL, 0, NULL, &dwAvail, NULL) && dwAvail > 0) {
            char szOut[1024] = {0};
            DWORD dwRead;
            if(ReadFile(hRead, szOut, sizeof(szOut) - 1, &dwRead, NULL)) {
                MessageBoxA(NULL, szOut, NULL, 0);
            }
        }
    }
    CloseHandle(hRead);
    CloseHandle(hWrite);
    
    return 0;
}
