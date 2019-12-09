

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Thu Oct 27 02:50:09 2011
 */
/* Compiler settings for AtlTest.idl:
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

MIDL_DEFINE_GUID(IID, IID_ITestCtl,0xD5357EA2,0xA70C,0x4173,0xBF,0x8E,0x80,0xB5,0x13,0x34,0xB6,0x7E);


MIDL_DEFINE_GUID(IID, LIBID_AtlTestLib,0xD189236A,0x6B6F,0x4F71,0x93,0x0F,0xDA,0xBF,0xC5,0x07,0xDB,0x3D);


MIDL_DEFINE_GUID(IID, DIID__ITestCtlEvents,0x69305E88,0x5229,0x45B0,0x8B,0xD1,0xC6,0x41,0x0A,0xD2,0x50,0x14);


MIDL_DEFINE_GUID(CLSID, CLSID_TestCtl,0x7A6A1B0B,0x3BAE,0x4BDF,0xBE,0x3B,0x50,0xC4,0x24,0xDF,0xE2,0x9D);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



