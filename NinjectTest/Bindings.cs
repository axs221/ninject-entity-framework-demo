using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace NinjectTest
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            Console.WriteLine("\r\n(loading Ninject bindings)\r\n");
            Bind<IDbConsole<Todo>>().To<DbConsole<Todo>>();
        }
    }
}
