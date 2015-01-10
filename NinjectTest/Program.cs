using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace NinjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(new INinjectModule[] {new Bindings()});

                var console = kernel.Get<IDbConsole<Todo>>();

                var app = new App();
                app.Execute(console);
            }
        }        
    }
}
