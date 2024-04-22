using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceService.ICustomServices
{
    public interface ICustomServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);

    }
}
