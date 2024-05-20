using LocalSalesInvoiceDOM.Data;
using LocalSalesInvoiceDOM.Models;
using LocalSalesInvoiceRepo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;


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

    //        var usersWithFriends = _context.Countries
    //.GroupJoin(_context.States, u => u.Id, f => f.CountryId, (u, f) => new
    //{
    //    Countries = u,
    //    States = f.Join(_context.Countries, f1 => f1.CountryId, u1 => u1.Id,
    //        (f1, u1) => u1)
    //})
    //.ToList();

           return await _entities.ToListAsync();
           
        }

        public IQueryable<dynamic> PerformDynamicJoins(List<string> entities, List<string> joinConditions)
        {
            if (entities == null || !entities.Any() || joinConditions == null || !joinConditions.Any())
                throw new ArgumentException("Entities and join conditions cannot be null or empty.");

            IQueryable query = _context.Set(Type.GetType($"Namespace.{entities[0]}"));

            for (int i = 1; i < entities.Count; i++)
            {
                string entityName = entities[i];
                string joinCondition = joinConditions[i - 1];

                Type entityType = Type.GetType($"Namespace.{entityName}");
                query = query.Join(_context.Set(entityType),
                                   joinCondition,
                                   $"new({joinCondition})",
                                   (outer, inner) => new { outer, inner });
            }

            return (IQueryable<dynamic>)query;
        }
    }
}
