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

	/* �W���u�I�u�W�F�N�g�̍쐬 */
	hJob = CreateJobObject(NULL, L"Test Job Object");
	pId = _wtoi(argv[1]);
	hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pId);

	if(hJob != NULL && hProcess != NULL){
		JOBOBJECT_BASIC_LIMIT_INFORMATION jbli;

		AssignProcessToJobObject(hJob, hProcess);
		SetInformationJobObject(hJob, JobObjectBasicLimitInformation, &jbli, sizeof(JOBOBJECT_BASIC_LIMIT_INFORMATION));
	}

	/* �ҋ@ */
	wprintf(L"wait... (Press Enter to Exit)");
	getchar();
	
	/* �W���u�I�u�W�F�N�g�̔j�� */
	CloseHandle(hProcess);
	CloseHandle(hJob);

	return 0;
}