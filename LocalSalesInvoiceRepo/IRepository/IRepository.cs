using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceRepo.IRepository
{
    //public interface IRepository<T>: This declares a public interface called IRepository that
    //is generic, meaning it can work with any type T
    public interface IRepository<T> 
    {
       Task<T> Get(int id);
       Task<IEnumerable<T>> GetAll();
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);
        void SaveChanges();

    }
    //By adding : IDisposable to the interface declaration, you are specifying that any class that implements IRepository<T> also needs to implement the Dispose() method defined in the IDisposable interface. This is useful for classes that use unmanaged resources that need to be cleaned up, such as file handles or database connections.
    //If you have classes implementing this interface, they will now need to provide an implementation for the Dispose() method as well.Here's an example of how a class might implement this extended IRepository<T> interface:
}
