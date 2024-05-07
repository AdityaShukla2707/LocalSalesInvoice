using LocalSalesInvoiceDOM.Data;
using LocalSalesInvoiceRepo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceRepo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region property
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;
        #endregion

        #region Constructor
        public Repository(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
            _entities = _context.Set<T>();   
        }

        #endregion
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            SaveChanges();
        }
        public void Insert(T entity)
        {
            //throw new NotImplementedException();
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            SaveChanges();
        }
       

        async Task<T> IRepository<T>.Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
