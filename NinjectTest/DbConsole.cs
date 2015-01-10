using System;
using System.Data.Entity;
using System.Linq;

namespace NinjectTest
{
    public class DbConsole<T> : IDbConsole<T> where T : class
    {
        public void WriteItem(T item)
        {
            var properties = item.GetType().GetProperties();
            foreach (var property in properties.Where(p => !p.Name.ToLower().Contains("id")))
            {
                Console.Write(property.Name);
                Console.Write(": ");
                Console.Write(property.GetValue(item, null).ToString().PadRight(40));
            }
            Console.WriteLine();
        }

        public void WriteItems(DbSet<T> items)
        {
            Console.WriteLine();
            Console.WriteLine("(loaded generic items from Entity Framework / SQL Server");
            Console.WriteLine();
            Console.WriteLine("Items\r\n---------");
            foreach (var item in items)
            {
                WriteItem(item);
            }
            Console.ReadLine();
        }
    }
}