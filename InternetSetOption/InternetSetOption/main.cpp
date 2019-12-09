#include <Windows.h>
#include <WinInet.h>
#include <stdio.h>

#pragma comment(lib, "Wininet.lib")

void TestInternetOption();

void main(void)
{
	TestInternetOption();
}

void TestInternetOption()
{
	HINTERNET hInternet;
	HINTERNET hFile;
	wchar_t Buf[2000];
	DWORD ReadSize;
	BOOL bResult;
	DWORD ms;

	hInternet = InternetOpen(
		L"WININET Sample Program",
		INTERNET_OPEN_TYPE_PRECONFIG,
		NULL,
		NULL,
		0);
	
	if(hInternet == NULL) wprintf(L"InternetOpen err(%d)\n", GetLastError());
	else wprintf(L"InternetOpen succeed.\n");

	ms = 1000;
	InternetSetOption(hInternet, INTERNET_OPTION_CONNECT_TIMEOUT, &ms, sizeof(ms));
	InternetSetOption(hInternet, INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT, &ms, sizeof(ms));
	InternetSetOption(hInternet, INTERNET_OPTION_CONTROL_SEND_TIMEOUT, &ms, sizeof(ms));
	InternetSetOption(hInternet, INTERNET_OPTION_DATA_SEND_TIMEOUT, &ms, sizeof(ms));
	InternetSetOption(hInternet, INTERNET_OPTION_DATA_RECEIVE_TIMEOUT, &ms, sizeof(ms));

	if(!bResult) wprintf(L"InternetSetOption err(%d)\n", GetLastError());
	else wprintf(L"InternetSetOption succeed.\n");

	hFile = InternetOpenUrl(
		hInternet,
		L"http://www.geocities.co.jp/SiliconValley-PaloAlto/5920/other.html",
		NULL,
		0,
		INTERNET_FLAG_EXISTING_CONNECT | INTERNET_FLAG_RELOAD,
		0);

	if(hFile == NULL) wprintf(L"InternetOpenUrl err(%d).\n", GetLastError());
	else wprintf(L"InternetOpenUrl succeed.\n");

	for(;;) {
		ReadSize = 2000;

		bResult = InternetReadFile(
			hFile,
			Buf,
			1000,
			&ReadSize);

		if(!bResult) {
			wprintf(L"err(%d)\n", GetLastError());
			break;
		}

		if(bResult && (ReadSize == 0)) break;

		Buf[ReadSize] = '\0';
		wprintf(L"%s", Buf);
	}

	InternetCloseHandle(hFile);
	InternetCloseHandle(hInternet);
}

