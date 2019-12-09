#include "stdafx.h"
#include "AtlThread.h"


HRESULT CWorkerClient::Execute(DWORD_PTR dwParam, HANDLE hObject)
{
	Sleep(5000);
	::MessageBox(NULL, L"TEST", L"TEST", MB_OK);

	return S_OK;
}

HRESULT CWorkerClient::CloseHandle(HANDLE hHandle)
{
	::CloseHandle(hHandle);

	return S_OK;
}