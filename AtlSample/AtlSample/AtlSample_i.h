

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Wed Oct 26 22:32:09 2011
 */
/* Compiler settings for AtlSample.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __AtlSample_i_h__
#define __AtlSample_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ITestCtl_FWD_DEFINED__
#define __ITestCtl_FWD_DEFINED__
typedef interface ITestCtl ITestCtl;
#endif 	/* __ITestCtl_FWD_DEFINED__ */


#ifndef ___ITestCtlEvents_FWD_DEFINED__
#define ___ITestCtlEvents_FWD_DEFINED__
typedef interface _ITestCtlEvents _ITestCtlEvents;
#endif 	/* ___ITestCtlEvents_FWD_DEFINED__ */


#ifndef __TestCtl_FWD_DEFINED__
#define __TestCtl_FWD_DEFINED__

#ifdef __cplusplus
typedef class TestCtl TestCtl;
#else
typedef struct TestCtl TestCtl;
#endif /* __cplusplus */

#endif 	/* __TestCtl_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __ITestCtl_INTERFACE_DEFINED__
#define __ITestCtl_INTERFACE_DEFINED__

/* interface ITestCtl */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ITestCtl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5BA748F0-77DE-40F4-9A6A-282DBE01631D")
    ITestCtl : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE TestFunc( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITestCtlVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITestCtl * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITestCtl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITestCtl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITestCtl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITestCtl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITestCtl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITestCtl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *TestFunc )( 
            ITestCtl * This);
        
        END_INTERFACE
    } ITestCtlVtbl;

    interface ITestCtl
    {
        CONST_VTBL struct ITestCtlVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITestCtl_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ITestCtl_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ITestCtl_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ITestCtl_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ITestCtl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ITestCtl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ITestCtl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define ITestCtl_TestFunc(This)	\
    ( (This)->lpVtbl -> TestFunc(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ITestCtl_INTERFACE_DEFINED__ */



#ifndef __AtlSampleLib_LIBRARY_DEFINED__
#define __AtlSampleLib_LIBRARY_DEFINED__

/* library AtlSampleLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_AtlSampleLib;

#ifndef ___ITestCtlEvents_DISPINTERFACE_DEFINED__
#define ___ITestCtlEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ITestCtlEvents */
/* [uuid] */ 


EXTERN_C const IID DIID__ITestCtlEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("7BAFF0A0-6AD2-4A63-B163-D76470DBF7FE")
    _ITestCtlEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ITestCtlEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ITestCtlEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ITestCtlEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ITestCtlEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ITestCtlEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ITestCtlEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ITestCtlEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ITestCtlEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ITestCtlEventsVtbl;

    interface _ITestCtlEvents
    {
        CONST_VTBL struct _ITestCtlEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ITestCtlEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ITestCtlEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ITestCtlEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ITestCtlEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ITestCtlEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ITestCtlEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ITestCtlEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ITestCtlEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TestCtl;

#ifdef __cplusplus

class DECLSPEC_UUID("BE432B54-C53E-4049-AABF-108D6EED9A83")
TestCtl;
#endif
#endif /* __AtlSampleLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


