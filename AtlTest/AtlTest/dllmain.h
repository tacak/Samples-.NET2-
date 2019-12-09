// dllmain.h : モジュール クラスの宣言

class CAtlTestModule : public ATL::CAtlDllModuleT< CAtlTestModule >
{
public :
	DECLARE_LIBID(LIBID_AtlTestLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLTEST, "{AAF7E7F1-ABA2-4B70-9E74-BB6FB5B24091}")
};

extern class CAtlTestModule _AtlModule;
