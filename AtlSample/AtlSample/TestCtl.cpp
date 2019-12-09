// TestCtl.cpp : CTestCtl の実装
#include "stdafx.h"
#include "TestCtl.h"


// CTestCtl


STDMETHODIMP CTestCtl::TestFunc(void)
{
	// TODO: ここに実装コードを追加してください。
	::MessageBox(NULL, L"TEST", L"TEST", MB_OK);

	return S_OK;
}
