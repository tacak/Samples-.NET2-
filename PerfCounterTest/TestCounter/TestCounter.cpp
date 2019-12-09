#include <windows.h>
#include "TestCounter.h"

// ���L�f�[�^�Z�O�����g�̍쐬
#pragma data_seg("SharedData")

long g_lInstanceCount = 0;
long g_lPerfdata1 = 50;
long g_lPerfdata2 = 0;

#pragma data_seg()

// ����́Adef �t�@�C���Őݒ肵�Ă��邪�A�ȉ��̂悤�Ȏw�����
// #pragma comment(linker, "/SECTION:SharedData,RWS")

// �G���g���|�C���g
BOOL APIENTRY DllMain( HANDLE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    return TRUE;
}

BOOL GetNumFromRegistry( 
     HKEY hHKey, 
     LPCTSTR lpszSubKey, 
     LPCTSTR lpszValueName, 
     DWORD* lpszData) {
     
          LONG lngRet;
          HKEY hKey;
          DWORD dwType;
          DWORD dwResult;
          DWORD dwSize = sizeof(DWORD);
          
          lngRet = RegOpenKeyEx(hHKey, lpszSubKey, 0, KEY_READ, &hKey);
     
          if(lngRet != ERROR_SUCCESS) {
               return FALSE;
          }
          
          lngRet = RegQueryValueEx(hKey, lpszValueName, 0,  &dwType, (BYTE*) &dwResult, &dwSize);
     
          if(ERROR_SUCCESS != lngRet || REG_DWORD != dwType) {
               RegCloseKey(hKey);
               return FALSE;
          }

          RegCloseKey(hKey);
     
          *lpszData = dwResult;
          
          return TRUE;
}


///////////////////////////////////////////////////////////////////////////////


DWORD CALLBACK PerftestOpen(PWSTR pwStr)
{
     // Read Registry Setting
     if (!GetNumFromRegistry (
          HKEY_LOCAL_MACHINE, 
          TEXT("SYSTEM\\CurrentControlSet\\Services\\TestPerf\\Performance"), 
          TEXT("First Counter"), 
          &g_dwObjectNameTitleIndex)) {
          return GetLastError ();
     }

     // Performance Data
     pPerfData = (TESTPERF_DATA) malloc (sizeof (TESTPERF_DATA));
     if (!pPerfData) {
          return ERROR_OUTOFMEMORY;
     }

     ::ZeroMemory (pPerfData, sizeof (TESTPERF_DATA));

     pPerfData->pot.TotalByteLength = sizeof(TESTPERF_DATA);
     pPerfData->pot.DefinitionLength = 
          sizeof (PERF_OBJECT_TYPE) + 3 * sizeof(PERF_COUNTER_DEFINITION);
     pPerfData->pot.HeaderLength = sizeof(PERF_OBJECT_TYPE);
     pPerfData->pot.ObjectNameTitleIndex = g_dwObjectNameTitleIndex;
     pPerfData->pot.ObjectNameTitle = NULL;
     pPerfData->pot.ObjectHelpTitleIndex = g_dwObjectNameTitleIndex + 1;
     pPerfData->pot.ObjectHelpTitle = NULL;
     pPerfData->pot.DetailLevel = PERF_DETAIL_NOVICE;
     pPerfData->pot.NumCounters = 3;
     pPerfData->pot.DefaultCounter = 0;
     pPerfData->pot.NumInstances = PERF_NO_INSTANCES;
     pPerfData->pot.CodePage = 0;

     pPerfData->pcd1.ByteLength = sizeof(PERF_COUNTER_DEFINITION);
     pPerfData->pcd1.CounterNameTitleIndex 
          = g_dwObjectNameTitleIndex + TESTPROGRAM_INSTANCE_COUNTER;
     pPerfData->pcd1.CounterNameTitle = NULL;
     pPerfData->pcd1.CounterHelpTitleIndex 
          = g_dwObjectNameTitleIndex + TESTPROGRAM_INSTANCE_COUNTER +1;
     pPerfData->pcd1.CounterHelpTitle = NULL;
     pPerfData->pcd1.DefaultScale = 0;
     pPerfData->pcd1.DetailLevel = PERF_DETAIL_NOVICE;
     pPerfData->pcd1.CounterType = PERF_COUNTER_RAWCOUNT;
     pPerfData->pcd1.CounterSize = sizeof (LONG);
     pPerfData->pcd1.CounterOffset = sizeof (PERF_COUNTER_BLOCK);

     pPerfData->pcd2.ByteLength = sizeof (PERF_COUNTER_DEFINITION);
     pPerfData->pcd2.CounterNameTitleIndex 
          = g_dwObjectNameTitleIndex + TESTPROGRAM_PERF1_COUNTER;
     pPerfData->pcd2.CounterNameTitle = NULL;
     pPerfData->pcd2.CounterHelpTitleIndex 
          = g_dwObjectNameTitleIndex + TESTPROGRAM_PERF1_COUNTER + 1;
     pPerfData->pcd2.CounterHelpTitle = NULL;
     pPerfData->pcd2.DefaultScale = 0;
     pPerfData->pcd2.DetailLevel = PERF_DETAIL_NOVICE;
     pPerfData->pcd2.CounterType = PERF_COUNTER_RAWCOUNT;
     pPerfData->pcd2.CounterSize = sizeof (LONG);
     pPerfData->pcd2.CounterOffset 
          = sizeof (PERF_COUNTER_BLOCK) + sizeof (LONG);

     pPerfData->pcb.ByteLength 
          = sizeof (PERF_COUNTER_BLOCK) + 3 * sizeof (LONG);

     return ERROR_SUCCESS;

}


///////////////////////////////////////////////////////////////////////////////


DWORD CALLBACK PerftestClose ()
{
     if (pPerfData) {
          free (pPerfData);
          pPerfData = NULL;
     }
     
     return ERROR_SUCCESS;
}


///////////////////////////////////////////////////////////////////////////////


DWORD CALLBACK PerftestCollect(
     PWSTR pszValueName,
     PVOID* ppvData,
     PDWORD pcbTotalBytes,
     PDWORD pdwNumObjectTypes)
{
     pPerfData->lInstanceCount = g_lInstanceCount;
     pPerfData->lPerf1 = g_lPerf1;

     ::CopyMemory (*ppvData, pPerfData, sizeof (TESTPERF_DATA));

     *ppvData = (char*)(*ppvData) + sizeof (MYPERF_DATA);
     *pcbTotalBytes = sizeof (MYPERF_DATA);
     *pdwNumObjectTypes = 1;
     
     return ERROR_SUCCESS;
}

long _stdcall GetPerformanceData(TESTPERF_TYPE t)
{
	switch(t){
	  case TT_INSTANCE:
	    return g_lInstanceCount;
	  case TT_DATA1:
	    return g_lPerfdata1;
	  case TT_DATA2:
	    return g_lPerfdata2;
	}
	return 0;
}

long _stdcall ChangePerformanceData(TESTPERF_TYPE t, long n)
{
	switch(t){
	  case TT_INSTANCE:
	    g_lInstanceCount += n;
	    return g_lInstanceCount;
	  case TT_DATA1:
	    g_lPerfdata1 += n;
	    return g_lPerfdata1;
	  case TT_DATA2:
	    g_lPerfdata2 += n;
	    return g_lPerfdata2;
	}
	return 0;
}
