// dllmain.cpp : DllMain �̎���

#include "stdafx.h"
#include "resource.h"
#include "AtlTest_i.h"
#include "dllmain.h"

CAtlTestModule _AtlModule;

// DLL �G���g�� �|�C���g
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _AtlModule.DllMain(dwReason, lpReserved); 
}