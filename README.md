# Nitter [![Nuget](https://img.shields.io/nuget/v/Nitter)](https://www.nuget.org/packages/Nitter/)

Nitter is a library to allow you mock/intercept any method on .NET.  

Don't need interfaces, abstract or be "virtual". 

Nitter is just a abstraction for [Jitex](https://github.com/Hitmasu/Jitex).

## Introducing

To mock a method, just pass your on method on `Nit.On` to prepare method to be mocked/intercepted. If your method is a non-void, you should call `Nit.On<TResult>` passing return type on `TResult`.

After prepare method, call `DoAsync` passing your interceptor/mock method. Like `Nit.On`, if your method as parameters, just call `DoAsync<>` passing type from parameters. 

Bellow, you can see a example how to mock a static method:

```c#
using System;
using Nitter;

Nit.On<int>(MathUtils.Sum) //.On<int>, int is return type from Sum
    .DoAsync<int, int>(async (n1, n2, context) => {
			return	n1 * n2; 
    });  //DoAsync<int,int> is parameter type from n1 and n2.

int sum = MathUtils.Sum(10, 10);
Console.WriteLine(sum); //Output is 100.

public class MathUtils
{
    public static int Sum(int n1, int n2)
    {
        return n1 + n2;
    }
}
```

### Intercepting call

```c#
Nit.On<int>(MathUtils.Sum)
    .DoAsync<int, int>(async (n1, n2, context) =>
    {
        int sum = await context.ContinueAsync<int>(); //Call original method.
        Console.WriteLine($"Return from method: {sum}");
        return sum * sum;
    });

int sum = MathUtils.Sum(10, 10);
Console.WriteLine(sum); //Output is 400.

public class MathUtils
{
    public static int Sum(int n1, int n2)
    {
        return n1 + n2;
    }
}
```

### Instance method

##### Option 1: Passing by expression

```c#
Nit<MathUtils>.On(w => w.Sum(default, default))
    .DoAsync<int, int>(async (n1, n2, context) => n1 * n2);

MathUtils utils = new MathUtils();

int sum = utils.Sum(10, 10);

public class MathUtils
{
    public int Sum(int n1, int n2)
    {
        return n1 + n2;
    }
}
```

##### Option 2: Passing by method group

```c#
MathUtils utils = new MathUtils();

Nit.On<int>(utils.Sum)
    .DoAsync<int, int>(async (n1, n2, context) => n1 * n2);

int sum = utils.Sum(10, 10);

public class MathUtils
{
    public int Sum(int n1, int n2)
    {
        return n1 + n2;
    }
}
```

### Generic methods

Currently, Nitter don't have a "typed way" to intercept or mock a generic method, but you can still doing that. Just replace your generic argument type by object:

```c#
Nit<MathUtils>.On(w => w.Sum<object>(default))
    .DoAsync<int>(async (parameter, context) => parameter * parameter);

int sum = new MathUtils().Sum(10);
Console.WriteLine(sum); //Output is 100

public class MathUtils
{
    public T Sum<T>(T parameter)
    {
        return parameter;
    }
}
```

### Non-public methods

To intercept a non-public method, just pass the MethodBase from method you want:

```c#
MethodBase methodSum = typeof(MathUtils).GetMethod("PrivateSum", BindingFlags.NonPublic | BindingFlags.Static);

Nit.On<int>(methodSum)
    .DoAsync<int, int>(async (n1, n2, context) =>
    {
        return n1 * n2;
    });

int sum = MathUtils.Sum(10, 10);
Console.WriteLine(sum); //Output is 100.

public class MathUtils
{
    public static int Sum(int n1, int n2)
    {
        return PrivateSum(n1, n2);
    }

    private static int PrivateSum(int n1, int n2)
    {
        return n1 + n2;
    }
}
```
