#include <windows.h>
#include <winperf.h>

typedef struct _TESTPERF_DATA{
     PERF_OBJECT_TYPE pot;
     PERF_COUNTER_DEFINITION pcd1;
     PERF_COUNTER_DEFINITION pcd2;
	 PERF_COUNTER_DEFINITION pcd3;
     PERF_COUNTER_BLOCK pcb;
     long lInstanceCount;
     long lPerfdata1;
	 long lPerfdata2;
} TESTPERF_DATA, *PTESTPERF_DATA;

typedef enum _TESTPERF_TYPE{
	TT_INSTANCE,
	TT_DATA1,
	TT_DATA2
} TESTPERF_TYPE;

long _stdcall GetPerformanceData(TESTPERF_TYPE t);
long _stdcall ChangePerformanceData(TESTPERF_TYPE t, long n);
