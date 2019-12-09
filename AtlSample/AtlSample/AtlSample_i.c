

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


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


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_ITestCtl,0x5BA748F0,0x77DE,0x40F4,0x9A,0x6A,0x28,0x2D,0xBE,0x01,0x63,0x1D);


MIDL_DEFINE_GUID(IID, LIBID_AtlSampleLib,0x4F1752D1,0x4B70,0x4775,0xBB,0x0F,0xEC,0x34,0xB3,0x7C,0xC8,0x95);


MIDL_DEFINE_GUID(IID, DIID__ITestCtlEvents,0x7BAFF0A0,0x6AD2,0x4A63,0xB1,0x63,0xD7,0x64,0x70,0xDB,0xF7,0xFE);


MIDL_DEFINE_GUID(CLSID, CLSID_TestCtl,0xBE432B54,0xC53E,0x4049,0xAA,0xBF,0x10,0x8D,0x6E,0xED,0x9A,0x83);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



