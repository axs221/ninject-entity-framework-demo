using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectTest
{
    internal class App
    {
        private static void AddTodo(TodoContext context)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" - - - - - - - - - - - - - - - - -");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Creating a new TODO item");

                context.Todos.Add(
                    new Todo
                    {
                        Title = PromptFor("Title"),
                        Description = PromptFor("Description")
                    });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.InnerException.Message);
                Console.WriteLine(Environment.CurrentDirectory);
                Console.ReadLine();
            }
        }

        private static string PromptFor(string promptName)
        {
            Console.WriteLine();
            Console.Write("{0}: ", promptName);
            return Console.ReadLine();
        }

        public void Execute(IDbConsole<Todo> console)
        {
            using (var context = new TodoContext())
            {
                Console.Write(@"
Simple 'TODO' application. 
It currently just creates a to-do item, accepting a title and description. 
Then it displays all todo-items loaded from SQL Server.

This demonstrates basic usage of Ninject and Entity Framework with SQL Server, and a simple generic class (DbConsole).

Press any key to continue.
");

                Console.ReadKey();

                AddTodo(context);

                console.WriteItems(context.Todos);
            }
        }
    }
}
