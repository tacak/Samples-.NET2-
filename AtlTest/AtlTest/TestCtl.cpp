// TestCtl.cpp : CTestCtl ‚ÌŽÀ‘•
#include "stdafx.h"
#include "TestCtl.h"
#include "atlthread.h"
#include "atlutil.h"

// CTestCtl
/*
void Thread1(LPARAM arg)
{
	//CTestCtl *tc = (CTestCtl*)arg;

	//Sleep(5000);
	//PostMessage(tc->m_hWnd, WM_THREADFIREEVENT, (WPARAM)NULL, (LPARAM)NULL);
	std::vector<IStream*>::iterator it;
	std::vector<IDispatch*> dispatches;
	std::vector<IDispatch*>::iterator itdispatch;

	for ( it = streams.begin(); it != streams.end(); ++it){
		IDispatch* dispatch = 0;
		CoGetInterfaceAndReleaseStream( *it, IID_IDispatch, (void**) &dispatch);
		dispatches.push_back( dispatch);
	}
	CComVariant varResult;
	CComVariant* pvars = new CComVariant[1];
	pvars[0] = NULL;
	DISPPARAMS disp = { pvars, NULL, 1, 0 };

	(*itdispatch)->Invoke(1, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, &varResult, NULL, NULL);
}
*/

STDMETHODIMP CTestCtl::TestFunc(void)
{
	_beginthread((void(*)(void*))Thread1 ,0, this);

	return S_OK;
}


LRESULT CTestCtl::OnFireEventForThread(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	Fire_TestEvent();

	return S_OK;
}

void CTestCtl::Thread1(void* arg)
{
	CTestCtl *tc = (CTestCtl *)arg;

	Sleep(5000);
	::PostMessage(tc->m_hWnd, WM_THREADFIREEVENT, (WPARAM)NULL, (LPARAM)NULL);
}
