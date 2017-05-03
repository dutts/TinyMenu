using System;
using System.Threading;

namespace TinyMenu.TestConsole.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Tiny.Menu("Main")
                ._("Foo", () => { Console.WriteLine("Foo"); Thread.Sleep(1000); })
                ._("Bar", () => { Console.WriteLine("Bar"); Thread.Sleep(1000); })
                ._(
                    Tiny.Menu("Sub")
                    ._("SubItem", () => { Console.WriteLine("SubItem"); Thread.Sleep(1000); })
                )
                .Show();
        }
    }
}
