# ReflectionShortcut
A set of shorcuts which helps you to utilize reflection functions.

EXAMPLES
----
```cs
var foo = new Foo();

// foo.GetType().GetMethod("Sum").Invoke(foo, new object[] {1, 2});
foo.Invoke("Sum", 1, 2);
```
