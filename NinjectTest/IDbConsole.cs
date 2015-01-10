using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace NinjectTest
{
    public interface IDbConsole<T> where T : class
    {
        void WriteItem(T item);
        void WriteItems(DbSet<T> items);
    }
}
