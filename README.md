# ReflectionShortcut
A set of shorcuts which helps you to utilize reflection functions.

EXAMPLES
----
```cs
var foo = new Foo();

// foo.GetType().GetMethod("Sum").Invoke(foo, new object[] {1, 2});
foo.Invoke("Sum", 1, 2);

// typeof(Foo).GetMethod("StaticSum").Invoke(null, new object[] {1, 2});
typeof(Foo).InvokeStatic("StaticSum", 1,2);
```
```cs
// typeof(Foo).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
typeof(Foo).GetPublicInstanceMethods();
```
