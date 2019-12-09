#include <Windows.h>
#include <stdio.h>
#include <ddraw.h>
#include <unknwn.h>

#pragma comment(lib, "ddraw.lib")
#pragma comment(lib, "dxguid.lib")

void wmain(void)
{   
    LPDIRECTDRAW7 lpDD7;
    LPDIRECTDRAW lpDD;
    DDSCAPS2      ddsCaps2;
    DWORD         dwTotal = 0;
    DWORD         dwFree = 0;
    HRESULT       hr;

    CoInitialize(NULL);

    hr = DirectDrawCreate(NULL,&lpDD,NULL);
    if (FAILED(hr))
        return ;

    hr = lpDD->QueryInterface(IID_IDirectDraw7, (LPVOID*)&lpDD7);
    if (FAILED(hr))
        return ; 

    ZeroMemory(&ddsCaps2, sizeof(ddsCaps2));
    ddsCaps2.dwCaps = DDSCAPS_VIDEOMEMORY;
       
    hr = lpDD7->GetAvailableVidMem(&ddsCaps2, &dwTotal, &dwFree);
    if (FAILED(hr))
        return ;

    wprintf(L"Total: %d\n", dwTotal);
	wprintf(L" Free: %d\n", dwFree);
	
	CoUninitialize();
}
