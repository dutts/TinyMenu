# TinyMenu

![Build Status](https://ci.appveyor.com/api/projects/status/github/dutts/tinymenu)

A tiny console menu builder for C#, supports .Net Framework and Standard.

## Usage

```csharp
Tiny.Menu("Main")
    ._("Foo", () => { Console.WriteLine("Foo"); Thread.Sleep(1000); })
    ._("Bar", () => { Console.WriteLine("Bar"); Thread.Sleep(1000); })
    ._(
       Tiny.Menu("Sub")
           ._("SubItem", () => { Console.WriteLine("SubItem"); Thread.Sleep(1000); })
       )
    .Show();
```
https://www.nuget.org/packages/TinyMenu/

