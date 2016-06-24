using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

public static class RSExt
{
    public static object InvokeStatic(
        this Type type,
        string name,
        params object[] args)
    {
        var method = type.GetMethod(name);
        return method.Invoke(null, args);
    }
    public static object Invoke(
        this Type type,
        object _this,
        string name,
        params object[] args)
    {
        var method = type.GetMethod(name);
        return method.Invoke(_this, args);
    }
    public static object Invoke(
        this object _this,
        string name,
        params object[] args)
    {
        return _this.GetType().Invoke(_this, name, args);
    }

    public static IEnumerable<MethodInfo> GetPublicStaticMethods(
        this Type type)
    {
        return type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod);
    }
    public static IEnumerable<MethodInfo> GetPublicInstanceMethods(
        this Type type)
    {
        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod);
    }

    public static IEnumerable<PropertyInfo> GetPublicStaticProperties(
        this Type type)
    {
        return type.GetProperties(BindingFlags.Public | BindingFlags.Static);
    }
    public static IEnumerable<PropertyInfo> GetPublicInstanceProperties(
        this Type type)
    {
        return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public static IEnumerable<Tuple<MethodInfo, T>> GetPublicInstanceMethodsWithAttribute<T>(
        this Type type,
        bool inherit = false)
        where T : Attribute
    {
        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Select(x =>
            new Tuple<MethodInfo, T>(
                x,
                x.GetCustomAttribute<T>(inherit)
            ))
            .Where(x => x.Item2 != null);
    }
