﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// System.Xml.Serialization.XmlElementEventHandler
struct XmlElementEventHandler_t2149916871;
// System.Object
struct Il2CppObject;
// System.Xml.Serialization.XmlElementEventArgs
struct XmlElementEventArgs_t2164317948;
// System.IAsyncResult
struct IAsyncResult_t2754620036;
// System.AsyncCallback
struct AsyncCallback_t1369114871;

#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Object4170816371.h"
#include "mscorlib_System_IntPtr4010401971.h"
#include "System_Xml_System_Xml_Serialization_XmlElementEven2164317948.h"
#include "mscorlib_System_AsyncCallback1369114871.h"

// System.Void System.Xml.Serialization.XmlElementEventHandler::.ctor(System.Object,System.IntPtr)
extern "C"  void XmlElementEventHandler__ctor_m905419850 (XmlElementEventHandler_t2149916871 * __this, Il2CppObject * ___object0, IntPtr_t ___method1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.Serialization.XmlElementEventHandler::Invoke(System.Object,System.Xml.Serialization.XmlElementEventArgs)
extern "C"  void XmlElementEventHandler_Invoke_m1452419704 (XmlElementEventHandler_t2149916871 * __this, Il2CppObject * ___sender0, XmlElementEventArgs_t2164317948 * ___e1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.IAsyncResult System.Xml.Serialization.XmlElementEventHandler::BeginInvoke(System.Object,System.Xml.Serialization.XmlElementEventArgs,System.AsyncCallback,System.Object)
extern "C"  Il2CppObject * XmlElementEventHandler_BeginInvoke_m4261089987 (XmlElementEventHandler_t2149916871 * __this, Il2CppObject * ___sender0, XmlElementEventArgs_t2164317948 * ___e1, AsyncCallback_t1369114871 * ___callback2, Il2CppObject * ___object3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Xml.Serialization.XmlElementEventHandler::EndInvoke(System.IAsyncResult)
extern "C"  void XmlElementEventHandler_EndInvoke_m659080026 (XmlElementEventHandler_t2149916871 * __this, Il2CppObject * ___result0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
