#include <tchar.h>
#include <stdio.h>
#include <Windows.h>
#include <locale.h>
#include <setupapi.h>
#include <cfgmgr32.h>
#include <devguid.h>

#pragma comment (lib, "setupapi.lib")

#define PRINTSPC \
for (int i = 0; i < level; i++) { _tprintf(_T("  ")); }

DEVINST _getPcDevInst()
{
	HDEVINFO hDevInfo;
	DWORD idx;
	SP_DEVINFO_DATA sdd;
	BOOL result;
	TCHAR buffer[1024];
	DWORD size;

	hDevInfo = ::SetupDiGetClassDevs(NULL, NULL, NULL, DIGCF_ALLCLASSES);
	idx = 0;

	while (true) {
		sdd.cbSize = sizeof(SP_DEVINFO_DATA);
		result = ::SetupDiEnumDeviceInfo(hDevInfo, idx, &sdd);

		if (!result) {
			break;
		}


		if (sdd.ClassGuid == GUID_DEVCLASS_COMPUTER) {
			size = sizeof(buffer) / sizeof(TCHAR);
			::SetupDiGetDeviceRegistryProperty(hDevInfo, &sdd, SPDRP_DEVICEDESC, NULL, (PBYTE)buffer, size, &size);

			_tprintf(_T("[%s]\n"), buffer);

			return sdd.DevInst;
		}
		idx++;
	}
	return NULL;
}

void _getChild(DEVINST current, int level)
{
	TCHAR bufDesc[1024];
	TCHAR bufName[1024];
	DWORD size;
	DEVINST di;
	CONFIGRET result;

	result = CM_Get_Child(&di, current, 0);
	if (result == CR_SUCCESS) {

		bufName[0] = _T('\0');
		size = sizeof(bufName) / sizeof(TCHAR);

		result = ::CM_Get_DevNode_Registry_Property(di, CM_DRP_FRIENDLYNAME, NULL, bufName, &size, 0);
		size = sizeof(bufDesc) / sizeof(TCHAR);

		result = ::CM_Get_DevNode_Registry_Property(di, CM_DRP_DEVICEDESC, NULL, bufDesc, &size, 0);

		if (result == CR_SUCCESS) {
			PRINTSPC;

			_tprintf(_T("+ [%s] %s\n"), bufDesc, bufName);
		}

		_getChild(di, level + 1);

		while (true) {
			result = CM_Get_Sibling(&di, di, 0);
			if (result != CR_SUCCESS) {
				break;
			}

			bufName[0] = _T('\0');
			size = sizeof(bufName) / sizeof(TCHAR);
			result = ::CM_Get_DevNode_Registry_Property(di, CM_DRP_FRIENDLYNAME, NULL, bufName, &size, 0);

			size = sizeof(bufDesc) / sizeof(TCHAR);
			result = ::CM_Get_DevNode_Registry_Property(di, CM_DRP_DEVICEDESC, NULL, bufDesc, &size, 0);

			if (result == CR_SUCCESS) {
				PRINTSPC;
				_tprintf(_T("+ [%s] %s\n"), bufDesc, bufName);
			}

			_getChild(di, level + 1);
		}
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "Japanese");
	_getChild(_getPcDevInst(), 1);

	return 0;
}