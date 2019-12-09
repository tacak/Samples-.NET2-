// TestCtl.h : CTestCtl �̐錾
#pragma once
#include "resource.h"       // ���C�� �V���{��
#include <atlctl.h>
#include "AtlTest_i.h"
#include "_ITestCtlEvents_CP.h"
#include <atlwin.h>

#define WM_THREADFIREEVENT WM_APP+101

#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "DCOM �̊��S�T�|�[�g���܂�ł��Ȃ� Windows Mobile �v���b�g�t�H�[���̂悤�� Windows CE �v���b�g�t�H�[���ł́A�P��X���b�h COM �I�u�W�F�N�g�͐������T�|�[�g����Ă��܂���BATL ���P��X���b�h COM �I�u�W�F�N�g�̍쐬���T�|�[�g���邱�ƁA����т��̒P��X���b�h COM �I�u�W�F�N�g�̎����̎g�p�������邱�Ƃ���������ɂ́A_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ���`���Ă��������B���g�p�� rgs �t�@�C���̃X���b�h ���f���� 'Free' �ɐݒ肳��Ă���ADCOM Windows CE �ȊO�̃v���b�g�t�H�[���ŃT�|�[�g�����B��̃X���b�h ���f���Ɛݒ肳��Ă��܂����B"
#endif

using namespace ATL;



// CTestCtl
class ATL_NO_VTABLE CTestCtl :
	public CComObjectRootEx<CComSingleThreadModel>,
	public IDispatchImpl<ITestCtl, &IID_ITestCtl, &LIBID_AtlTestLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IOleControlImpl<CTestCtl>,
	public IOleObjectImpl<CTestCtl>,
	public IOleInPlaceActiveObjectImpl<CTestCtl>,
	public IViewObjectExImpl<CTestCtl>,
	public IOleInPlaceObjectWindowlessImpl<CTestCtl>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CTestCtl>,
	public CProxy_ITestCtlEvents<CTestCtl>,
	public IQuickActivateImpl<CTestCtl>,
#ifndef _WIN32_WCE
	public IDataObjectImpl<CTestCtl>,
#endif
	public IProvideClassInfo2Impl<&CLSID_TestCtl, &__uuidof(_ITestCtlEvents), &LIBID_AtlTestLib>,
	public CComCoClass<CTestCtl, &CLSID_TestCtl>,
	public CComControl<CTestCtl>
{
public:
	CTestCtl()
	{
	}

DECLARE_OLEMISC_STATUS(OLEMISC_RECOMPOSEONRESIZE |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_INSIDEOUT |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST
)

DECLARE_REGISTRY_RESOURCEID(IDR_TESTCTL)


BEGIN_COM_MAP(CTestCtl)
	COM_INTERFACE_ENTRY(ITestCtl)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IViewObjectEx)
	COM_INTERFACE_ENTRY(IViewObject2)
	COM_INTERFACE_ENTRY(IViewObject)
	COM_INTERFACE_ENTRY(IOleInPlaceObjectWindowless)
	COM_INTERFACE_ENTRY(IOleInPlaceObject)
	COM_INTERFACE_ENTRY2(IOleWindow, IOleInPlaceObjectWindowless)
	COM_INTERFACE_ENTRY(IOleInPlaceActiveObject)
	COM_INTERFACE_ENTRY(IOleControl)
	COM_INTERFACE_ENTRY(IOleObject)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IQuickActivate)
#ifndef _WIN32_WCE
	COM_INTERFACE_ENTRY(IDataObject)
#endif
	COM_INTERFACE_ENTRY(IProvideClassInfo)
	COM_INTERFACE_ENTRY(IProvideClassInfo2)
END_COM_MAP()

BEGIN_PROP_MAP(CTestCtl)
	PROP_DATA_ENTRY("_cx", m_sizeExtent.cx, VT_UI4)
	PROP_DATA_ENTRY("_cy", m_sizeExtent.cy, VT_UI4)
	// �G���g���̗�
	// PROP_ENTRY_TYPE("�v���p�e�B��", dispid, clsid, vtType)
	// PROP_PAGE(CLSID_StockColorPage)
END_PROP_MAP()

BEGIN_CONNECTION_POINT_MAP(CTestCtl)
	CONNECTION_POINT_ENTRY(__uuidof(_ITestCtlEvents))
END_CONNECTION_POINT_MAP()

BEGIN_MSG_MAP(CTestCtl)
	CHAIN_MSG_MAP(CComControl<CTestCtl>)
	DEFAULT_REFLECTION_HANDLER()
	MESSAGE_HANDLER(WM_THREADFIREEVENT, OnFireEventForThread)
END_MSG_MAP()
// �n���h���[ �v���g�^�C�v:
//  LRESULT MessageHandler(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
//  LRESULT CommandHandler(WORD wNotifyCode, WORD wID, HWND hWndCtl, BOOL& bHandled);
//  LRESULT NotifyHandler(int idCtrl, LPNMHDR pnmh, BOOL& bHandled);

// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid)
	{
		static const IID* const arr[] =
		{
			&IID_ITestCtl,
		};

		for (int i=0; i<sizeof(arr)/sizeof(arr[0]); i++)
		{
			if (InlineIsEqualGUID(*arr[i], riid))
				return S_OK;
		}
		return S_FALSE;
	}

// IViewObjectEx
	DECLARE_VIEW_STATUS(VIEWSTATUS_SOLIDBKGND | VIEWSTATUS_OPAQUE)

// ITestCtl
public:
	HRESULT OnDraw(ATL_DRAWINFO& di)
	{
		RECT& rc = *(RECT*)di.prcBounds;
		// �N���b�v�̈�� di.prcBounds �Ŏw�肳�ꂽ�l�p�`�ɐݒ肵�܂�
		HRGN hRgnOld = NULL;
		if (GetClipRgn(di.hdcDraw, hRgnOld) != 1)
			hRgnOld = NULL;
		bool bSelectOldRgn = false;

		HRGN hRgnNew = CreateRectRgn(rc.left, rc.top, rc.right, rc.bottom);

		if (hRgnNew != NULL)
		{
			bSelectOldRgn = (SelectClipRgn(di.hdcDraw, hRgnNew) != ERROR);
		}

		Rectangle(di.hdcDraw, rc.left, rc.top, rc.right, rc.bottom);
		SetTextAlign(di.hdcDraw, TA_CENTER|TA_BASELINE);
		LPCTSTR pszText = _T("TestCtl");
#ifndef _WIN32_WCE
		TextOut(di.hdcDraw,
			(rc.left + rc.right) / 2,
			(rc.top + rc.bottom) / 2,
			pszText,
			lstrlen(pszText));
#else
		ExtTextOut(di.hdcDraw,
			(rc.left + rc.right) / 2,
			(rc.top + rc.bottom) / 2,
			ETO_OPAQUE,
			NULL,
			pszText,
			ATL::lstrlen(pszText),
			NULL);
#endif

		if (bSelectOldRgn)
			SelectClipRgn(di.hdcDraw, hRgnOld);

		return S_OK;
	}


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		RECT rect;
       rect.left=0;
       rect.right=100;
       rect.top=0;
       rect.bottom=100;
       HWND hwnd = Create( NULL, rect, L"MyAtlWindow", WS_POPUP);

		return S_OK;
	}

	void FinalRelease()
	{
		if ( m_hWnd != NULL )
			DestroyWindow( );

	}

	STDMETHOD(TestFunc)(void);
	LRESULT OnFireEventForThread(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
	static void Thread1(void* arg);
};

OBJECT_ENTRY_AUTO(__uuidof(TestCtl), CTestCtl)
