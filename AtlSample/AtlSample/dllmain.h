// dllmain.h : モジュール クラスの宣言

class CAtlSampleModule : public ATL::CAtlDllModuleT< CAtlSampleModule >
{
public :
	DECLARE_LIBID(LIBID_AtlSampleLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSAMPLE, "{F6FA2F6F-7F94-47B2-B93A-77B336EC6321}")
};

extern class CAtlSampleModule _AtlModule;
