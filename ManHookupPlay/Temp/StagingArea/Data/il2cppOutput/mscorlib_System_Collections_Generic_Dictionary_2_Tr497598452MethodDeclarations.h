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

// System.Collections.Generic.Dictionary`2/Transform`1<Windows.Kinect.JointType,Windows.Kinect.Joint,Windows.Kinect.Joint>
struct Transform_1_t497598452;
// System.Object
struct Il2CppObject;
// System.IAsyncResult
struct IAsyncResult_t2754620036;
// System.AsyncCallback
struct AsyncCallback_t1369114871;

#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Object4170816371.h"
#include "mscorlib_System_IntPtr4010401971.h"
#include "AssemblyU2DCSharpU2Dfirstpass_Windows_Kinect_Joint2011134424.h"
#include "AssemblyU2DCSharpU2Dfirstpass_Windows_Kinect_Joint2966433458.h"
#include "mscorlib_System_AsyncCallback1369114871.h"

// System.Void System.Collections.Generic.Dictionary`2/Transform`1<Windows.Kinect.JointType,Windows.Kinect.Joint,Windows.Kinect.Joint>::.ctor(System.Object,System.IntPtr)
extern "C"  void Transform_1__ctor_m717235534_gshared (Transform_1_t497598452 * __this, Il2CppObject * ___object0, IntPtr_t ___method1, const MethodInfo* method);
#define Transform_1__ctor_m717235534(__this, ___object0, ___method1, method) ((  void (*) (Transform_1_t497598452 *, Il2CppObject *, IntPtr_t, const MethodInfo*))Transform_1__ctor_m717235534_gshared)(__this, ___object0, ___method1, method)
// TRet System.Collections.Generic.Dictionary`2/Transform`1<Windows.Kinect.JointType,Windows.Kinect.Joint,Windows.Kinect.Joint>::Invoke(TKey,TValue)
extern "C"  Joint_t2011134424  Transform_1_Invoke_m3047620586_gshared (Transform_1_t497598452 * __this, int32_t ___key0, Joint_t2011134424  ___value1, const MethodInfo* method);
#define Transform_1_Invoke_m3047620586(__this, ___key0, ___value1, method) ((  Joint_t2011134424  (*) (Transform_1_t497598452 *, int32_t, Joint_t2011134424 , const MethodInfo*))Transform_1_Invoke_m3047620586_gshared)(__this, ___key0, ___value1, method)
// System.IAsyncResult System.Collections.Generic.Dictionary`2/Transform`1<Windows.Kinect.JointType,Windows.Kinect.Joint,Windows.Kinect.Joint>::BeginInvoke(TKey,TValue,System.AsyncCallback,System.Object)
extern "C"  Il2CppObject * Transform_1_BeginInvoke_m4236906389_gshared (Transform_1_t497598452 * __this, int32_t ___key0, Joint_t2011134424  ___value1, AsyncCallback_t1369114871 * ___callback2, Il2CppObject * ___object3, const MethodInfo* method);
#define Transform_1_BeginInvoke_m4236906389(__this, ___key0, ___value1, ___callback2, ___object3, method) ((  Il2CppObject * (*) (Transform_1_t497598452 *, int32_t, Joint_t2011134424 , AsyncCallback_t1369114871 *, Il2CppObject *, const MethodInfo*))Transform_1_BeginInvoke_m4236906389_gshared)(__this, ___key0, ___value1, ___callback2, ___object3, method)
// TRet System.Collections.Generic.Dictionary`2/Transform`1<Windows.Kinect.JointType,Windows.Kinect.Joint,Windows.Kinect.Joint>::EndInvoke(System.IAsyncResult)
extern "C"  Joint_t2011134424  Transform_1_EndInvoke_m1834969696_gshared (Transform_1_t497598452 * __this, Il2CppObject * ___result0, const MethodInfo* method);
#define Transform_1_EndInvoke_m1834969696(__this, ___result0, method) ((  Joint_t2011134424  (*) (Transform_1_t497598452 *, Il2CppObject *, const MethodInfo*))Transform_1_EndInvoke_m1834969696_gshared)(__this, ___result0, method)