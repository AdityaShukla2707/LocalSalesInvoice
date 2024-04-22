using LocalSalesInvoiceDOM.Models;
using LocalSalesInvoiceService.ICustomServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalSalesInvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICustomServices<Country> _customServices;
       

        public CountryController(ICustomServices<Country> customServices)
        {
            _customServices = customServices;
        }

        [HttpPost(nameof(CreateCountry))]
        public IActionResult CreateCountry(Country country)
        {
            if (country != null)
            {
                 _customServices.Insert(country);
                return  Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
    }
}
