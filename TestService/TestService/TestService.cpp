#include <stdio.h>
#include <tchar.h>
#include <windows.h>
#include <Dbt.h>

#define SERVICE_NAME _T("TestService")
#define BUFFER_LENGTH 4096

SERVICE_STATUS_HANDLE serviceStatusHandle;
HANDLE serviceStopEvent = NULL;
_TCHAR logFileName[MAX_PATH + 1];

// 実行ファイル(EXE)のパスより、ログのパスを生成します。
// ログファイルの名前は、実行ファイル + ".log"になります。
void initLog(_TCHAR* executablePath)
{
    _tcscpy_s(logFileName, MAX_PATH + 1, executablePath);
    _tcscat_s(logFileName, MAX_PATH + 1, _T(".log"));
}

// ログファイルを開き、ログを出力します。
void log(const _TCHAR *format, ...)
{
    FILE *fp;
    if (_tfopen_s(&fp, logFileName, _T("a")) != 0) {
        return;
    }
    _TCHAR buff[BUFFER_LENGTH];
    va_list args;
    va_start(args, format);
    _vsntprintf_s(buff, BUFFER_LENGTH, _TRUNCATE, format, args);
    _ftprintf_s(fp, buff);
    fclose(fp);
}

DWORD WINAPI ServiceControlHandlerEx(DWORD control, DWORD eventType, LPVOID eventData, LPVOID context )
{
    // サービスステータス構造体の初期化
    SERVICE_STATUS serviceStatus;
    serviceStatus.dwServiceType = SERVICE_WIN32_OWN_PROCESS;
    serviceStatus.dwWin32ExitCode = NO_ERROR;
    serviceStatus.dwServiceSpecificExitCode = 0;
    serviceStatus.dwCheckPoint = 1;
    serviceStatus.dwWaitHint = 1000;
    serviceStatus.dwControlsAccepted = SERVICE_ACCEPT_STOP;
    serviceStatus.dwCurrentState = 0;

    BOOL ret = TRUE;
    DWORD returnCode;
    switch (control) {
    case SERVICE_CONTROL_INTERROGATE:
        // サービスの状態の問い合わせ
        log(_T("SERVICE_CONTROL_INTERROGATE\n"));
        serviceStatus.dwCurrentState = SERVICE_RUNNING;
        serviceStatus.dwCheckPoint = 0;
        serviceStatus.dwWaitHint = 0;
        ret = SetServiceStatus (serviceStatusHandle, &serviceStatus);
        returnCode = NO_ERROR;
        break;
	case SERVICE_CONTROL_DEVICEEVENT: 
		switch (eventType){
		case DBT_DEVICEARRIVAL:
			break;
		}
		break;
    case SERVICE_CONTROL_STOP:
        // サービスの停止
		SetEvent(serviceStopEvent);
        log(_T("SERVICE_CONTROL_STOP\n"));

        // SERVICE_STOP_PENDINGをSCMへ通知
        serviceStatus.dwCurrentState = SERVICE_STOP_PENDING;
        ret = SetServiceStatus (serviceStatusHandle, &serviceStatus);
        if (!ret) {
            log(_T("SetServiceStatus failed. %u\n"), GetLastError());
            returnCode = -1;
            break;
        }
        // 1秒間待機
        Sleep(1000);
        
        // SERVICE_STOPPEDをSCMへ通知
        serviceStatus.dwCurrentState = SERVICE_STOPPED;
        serviceStatus.dwCheckPoint = 0;
        serviceStatus.dwWaitHint = 0;
        ret = SetServiceStatus (serviceStatusHandle, &serviceStatus);
        if (!ret) {
            log(_T("SetServiceStatus failed. %u\n"), GetLastError());
            returnCode = -1;
            break;
        }
        returnCode = NO_ERROR;
        break;
    default:
        returnCode = ERROR_CALL_NOT_IMPLEMENTED;
    }
    return returnCode;
}

void WINAPI ServiceMain(DWORD argc, LPTSTR *argv)
{
    log(_T("Service Main started\n"));
    // サービスステータス構造体の初期化
    SERVICE_STATUS serviceStatus;
    serviceStatus.dwServiceType = SERVICE_WIN32_OWN_PROCESS;
    serviceStatus.dwWin32ExitCode = NO_ERROR;
    serviceStatus.dwServiceSpecificExitCode = 0;
    serviceStatus.dwCheckPoint = 1;
    serviceStatus.dwWaitHint = 1000;
    serviceStatus.dwControlsAccepted = SERVICE_ACCEPT_STOP;

    // サービスコントロールハンドラの登録
    serviceStatusHandle = RegisterServiceCtrlHandlerEx(SERVICE_NAME, ServiceControlHandlerEx, NULL);
    if (serviceStatusHandle == 0) {
        log(_T("RegisterServiceCtrlHandlerEx failed. %u\n"), GetLastError());
        return;
    }
    
    // サービスの初期化中であることをSCMへ通知
    serviceStatus.dwCurrentState = SERVICE_START_PENDING;
    BOOL ret = SetServiceStatus(serviceStatusHandle, &serviceStatus);
    if (!ret) {
        log(_T("SetServiceStatus failed. %u\n"), GetLastError());
        return;
    }

    // サービスの初期化コードをここに記述
    serviceStopEvent = CreateEvent(NULL, FALSE, TRUE, NULL);
	ResetEvent(serviceStopEvent);
    
	// デバイスイベントの検地
	DEV_BROADCAST_DEVICEINTERFACE notificationFilter; 
    HDEVNOTIFY hDeviceNotify = NULL;         
 
    ::ZeroMemory(&notificationFilter, sizeof(notificationFilter)); 
 
    notificationFilter.dbcc_size = sizeof(DEV_BROADCAST_DEVICEINTERFACE); 
    notificationFilter.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE; 
    notificationFilter.dbcc_classguid = ::GUID_DEVINTERFACE_VOLUME; 
 
    hDeviceNotify = ::RegisterDeviceNotification(serviceStatusHandle, &notificationFilter, DEVICE_NOTIFY_SERVICE_HANDLE);

    // サービスの実行が開始したことをSCMへ通知
    serviceStatus.dwCurrentState = SERVICE_RUNNING;
    serviceStatus.dwCheckPoint = 0;
    serviceStatus.dwWaitHint = 0;
    serviceStatus.dwControlsAccepted = SERVICE_ACCEPT_PAUSE_CONTINUE | SERVICE_ACCEPT_STOP;
    ret = SetServiceStatus(serviceStatusHandle, &serviceStatus);
    if (!ret) {
        log(_T("SetServiceStatus failed. %u\n"), GetLastError());
		CloseHandle(serviceStopEvent);
        return;
    }

    // サービスの処理本体をここに記述
	WaitForSingleObject(serviceStopEvent, INFINITE);
	CloseHandle(serviceStopEvent);
	
    log(_T("Service Main stopped\n"));
}

int _tmain(int argc, _TCHAR* argv[])
{
    initLog(argv[0]);
    log(_T("Main method started\n"));

	SERVICE_TABLE_ENTRY dispatchTable[] = {
        {SERVICE_NAME, ServiceMain},
        {NULL, NULL}
    };

    if (!StartServiceCtrlDispatcher(dispatchTable)) {
        log(_T("StartServiceCtrlDispatcher failed. %u\n"), GetLastError());
        return -1;
    }

    log(_T("Main method ended\n"));
    return 0;
}
