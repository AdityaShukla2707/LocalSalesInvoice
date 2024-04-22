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
            throw new NotImplementedException();
        }

        public Task<Country> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAll()
        {
            throw new NotImplementedException();
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

        public void Remove(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
