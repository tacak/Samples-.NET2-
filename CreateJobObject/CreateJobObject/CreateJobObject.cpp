#include <windows.h>
#include <stdio.h>

int wmain(int argc, wchar_t *argv[])
{
	HANDLE hJob;
	HANDLE hProcess;
	int pId, i;

	if(argc != 2){
		wprintf(L"CreateJobObject.exe <ProcessName>\n");
		return 1;
	}

	/* ジョブオブジェクトの作成 */
	hJob = CreateJobObject(NULL, L"Test Job Object");
	pId = _wtoi(argv[1]);
	hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pId);

	if(hJob != NULL && hProcess != NULL){
		JOBOBJECT_BASIC_LIMIT_INFORMATION jbli;

		AssignProcessToJobObject(hJob, hProcess);
		SetInformationJobObject(hJob, JobObjectBasicLimitInformation, &jbli, sizeof(JOBOBJECT_BASIC_LIMIT_INFORMATION));
	}

	/* 待機 */
	wprintf(L"wait... (Press Enter to Exit)");
	getchar();
	
	/* ジョブオブジェクトの破棄 */
	CloseHandle(hProcess);
	CloseHandle(hJob);

	return 0;
}