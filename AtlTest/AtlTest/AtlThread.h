#include "stdafx.h"
#include "TestCtl.h"
#include "atlutil.h"

class CWorkerClient: public IWorkerThreadClient {
  public:
	CWorkerClient() {};
	HRESULT Execute(DWORD_PTR dwParam, HANDLE hObject);
	HRESULT CloseHandle(HANDLE hHandle);
};