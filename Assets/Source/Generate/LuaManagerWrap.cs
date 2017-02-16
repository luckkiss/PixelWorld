﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaManager), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("GetInstance", GetInstance);
		L.RegFunction("InitStart", InitStart);
		L.RegFunction("DoFile", DoFile);
		L.RegFunction("CallFunction", CallFunction);
		L.RegFunction("LuaGC", LuaGC);
		L.RegFunction("Close", Close);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 1);
			LuaManager o = LuaManager.GetInstance(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitStart(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaManager obj = (LuaManager)ToLua.CheckObject(L, 1, typeof(LuaManager));
			obj.InitStart();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaManager obj = (LuaManager)ToLua.CheckObject(L, 1, typeof(LuaManager));
			string arg0 = ToLua.CheckString(L, 2);
			object[] o = obj.DoFile(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallFunction(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaManager obj = (LuaManager)ToLua.CheckObject(L, 1, typeof(LuaManager));
			string arg0 = ToLua.CheckString(L, 2);
			object[] arg1 = ToLua.ToParamsObject(L, 3, count - 2);
			object[] o = obj.CallFunction(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaGC(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaManager obj = (LuaManager)ToLua.CheckObject(L, 1, typeof(LuaManager));
			obj.LuaGC();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Close(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaManager obj = (LuaManager)ToLua.CheckObject(L, 1, typeof(LuaManager));
			obj.Close();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

