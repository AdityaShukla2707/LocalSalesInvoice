using LocalSalesInvoiceDOM.Models;
using LocalSalesInvoiceRepo.IRepository;
using LocalSalesInvoiceService.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSalesInvoiceService.CustomServices
{
    public class StateServices : ICustomServices<State>
    {
        private readonly IRepository<State> _stateRepository;

        public StateServices(IRepository<State> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public void Delete(State entity)
        {
            try
            {
                if (entity != null)
                {
                    _stateRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete state.", ex);
            }
        }

        public async  Task<State> Get(int Id)
        {
            return await _stateRepository.Get(Id);
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            
            return await _stateRepository.GetAll();
        }

        public void Insert(State entity)
        {
            //throw new NotImplementedException();
            try
            {
                if (entity != null)
                {
                    _stateRepository.Insert(entity);
                    _stateRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(State entity)
        {
            throw new NotImplementedException();
        }

        public void Update(State entity)
        {
            try
            {
                if (entity != null)
                {
                    _stateRepository.Update(entity);
                    _stateRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update state.", ex);
            }
        }
    }
}
