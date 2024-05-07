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
    public class CountryServices : ICustomServices<Country>
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryServices(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void Delete(Country entity)
        {
            try
            {
                if (entity != null)
                {
                    _countryRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete country.", ex);
            }
        }

        public async  Task<Country> Get(int Id)
        {
            return await _countryRepository.Get(Id);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
           return await _countryRepository.GetAll();
        }

        public void Insert(Country entity)
        {
            //throw new NotImplementedException();
            try
            {
                if (entity != null)
                {
                    _countryRepository.Insert(entity);
                    _countryRepository.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Update(Country entity)
        {
            try
            {
                if (entity != null)
                {
                    _countryRepository.Update(entity);
                    _countryRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update country.", ex);
            }
        }
    }
}
