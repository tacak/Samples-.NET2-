// TestCtl.cpp : CTestCtl �̎���
#include "stdafx.h"
#include "TestCtl.h"


// CTestCtl


STDMETHODIMP CTestCtl::TestFunc(void)
{
	// TODO: �����Ɏ����R�[�h��ǉ����Ă��������B
	::MessageBox(NULL, L"TEST", L"TEST", MB_OK);

	return S_OK;
}
