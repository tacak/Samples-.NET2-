#include <windows.h>

BOOL CreateSessionKey(HCRYPTPROV hProv, LPBYTE lpData, DWORD dwDataSize, HCRYPTKEY *phKey);
BOOL EncryptData(HCRYPTKEY hKey, LPTSTR lpszFileName, LPBYTE lpData, DWORD dwDataSize, LPBYTE lpBuffer, DWORD dwBufferSize);
BOOL DecryptData(HCRYPTKEY hKey, LPTSTR lpszFileName, LPBYTE lpBuffer, DWORD dwBufferSize);

int WINAPI WinMain(HINSTANCE hinst, HINSTANCE hinstPrev, LPSTR lpszCmdLine, int nCmdShow)
{
	TCHAR      szFileName[] = TEXT("sample.txt");
	TCHAR      szPassword[] = TEXT("password");
	TCHAR      szData[] = TEXT("sample-data");
	TCHAR      szBuf[256];
	HCRYPTPROV hProv;
	HCRYPTKEY  hKey;
	BOOL       bEncrypt = TRUE;
	
	if (!CryptAcquireContext(&hProv, NULL, NULL, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT)) {
		MessageBox(NULL, TEXT("CSPのハンドルの取得に失敗しました。"), NULL, MB_ICONWARNING);
		return 0;
	}

	if (!CreateSessionKey(hProv, (LPBYTE)szPassword, sizeof(szPassword), &hKey)) {
		MessageBox(NULL, TEXT("セッション鍵の作成に失敗しました。"), NULL, MB_ICONWARNING);
		CryptReleaseContext(hProv, 0);
		return 0;
	}

	if (bEncrypt) {
		if (EncryptData(hKey, szFileName, (LPBYTE)szData, sizeof(szData), (LPBYTE)szBuf, sizeof(szBuf))) 
			MessageBox(NULL, TEXT("暗号化しました。"), TEXT("OK"), MB_OK);
	}
	else {
		if (DecryptData(hKey, szFileName, (LPBYTE)szBuf, sizeof(szBuf)))
			MessageBox(NULL, szBuf, TEXT("OK"), MB_OK);
	}

	CryptDestroyKey(hKey);
	CryptReleaseContext(hProv, 0);

	return 0;
}

BOOL CreateSessionKey(HCRYPTPROV hProv, LPBYTE lpData, DWORD dwDataSize, HCRYPTKEY *phKey)
{
	BOOL       bResult;
	HCRYPTHASH hHash;

	if (!CryptCreateHash(hProv, CALG_MD5, 0, 0, &hHash))
		return FALSE;
	
	CryptHashData(hHash, lpData, dwDataSize, 0);
	
	bResult = CryptDeriveKey(hProv, CALG_RC4, hHash, 0, phKey);
	
	CryptDestroyHash(hHash);

	return bResult;
}

BOOL EncryptData(HCRYPTKEY hKey, LPTSTR lpszFileName, LPBYTE lpData, DWORD dwDataSize, LPBYTE lpBuffer, DWORD dwBufferSize)
{
	HANDLE hFile;
	DWORD  dwWriteByte;
	BOOL   bResult;

	if (dwDataSize > dwBufferSize)
		return FALSE;
	
	CopyMemory(lpBuffer, lpData, dwDataSize);
	bResult = CryptEncrypt(hKey, 0, TRUE, 0, lpBuffer, &dwDataSize, dwBufferSize);
	if (!bResult)
		return FALSE;
	
	hFile = CreateFile(lpszFileName, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	WriteFile(hFile, lpBuffer, dwDataSize, &dwWriteByte, NULL);
	CloseHandle(hFile);

	return TRUE;
}

BOOL DecryptData(HCRYPTKEY hKey, LPTSTR lpszFileName, LPBYTE lpBuffer, DWORD dwBufferSize)
{
	HANDLE hFile;
	DWORD  dwReadByte;
	DWORD  dwDataSize;
	BOOL   bResult;

	hFile = CreateFile(lpszFileName, GENERIC_READ, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hFile == INVALID_HANDLE_VALUE)
		return FALSE;

	dwDataSize = GetFileSize(hFile, NULL);
	if (dwDataSize > dwBufferSize) {
		CloseHandle(hFile);
		return FALSE;
	}

	ReadFile(hFile, lpBuffer, dwDataSize, &dwReadByte, NULL);
	CloseHandle(hFile);

	bResult = CryptDecrypt(hKey, 0, TRUE, 0, lpBuffer, &dwDataSize);

	return bResult;
}
