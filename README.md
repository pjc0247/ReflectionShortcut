# ReflectionShortcut
A set of shorcuts which helps you to utilize reflection functions.

EXAMPLES
----
__Invoke__
```cs
var foo = new Foo();

// foo.GetType().GetMethod("Sum").Invoke(foo, new object[] {1, 2});
foo.Invoke("Sum", 1, 2);

// typeof(Foo).GetMethod("StaticSum").Invoke(null, new object[] {1, 2});
typeof(Foo).InvokeStatic("StaticSum", 1,2);
```
__Query Methods__
```cs
// typeof(Foo).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
typeof(Foo).GetPublicInstanceMethods();

// typeof(Foo).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
//     .Select(x => new Tuple<MethodInfo, MyCustomAttribute>(x, x.GetCustomAttribute<T>()))
//     .Where(x => x.Item2 != null);
typeof(Foo).GetPublicInstanceMethodsWithAttribute<MyCustomAttribute>()
```
