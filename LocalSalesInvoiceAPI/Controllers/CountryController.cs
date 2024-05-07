using LocalSalesInvoiceDOM.Models;
using LocalSalesInvoiceService.ICustomServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateCountry([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Invalid country data.");
            }

            try
            {
                _customServices.Insert(country);
                return Ok("Country created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the country: {ex.Message}");
            }
        }

        [HttpGet(nameof(GetAllCountries))]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _customServices.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving countries: {ex.Message}");
            }
        }

        [HttpGet(nameof(GetCountryById) + "/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var country = await _customServices.Get(id);
                if (country == null)
                {
                    return NotFound("Country not found.");
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the country: {ex.Message}");
            }
        }

        [HttpPut(nameof(UpdateCountry))]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] Country country)
        {
            try
            {
                var existingCountry = await _customServices.Get(id);
                if (existingCountry == null)
                {
                    return NotFound("Country not found.");
                }

                existingCountry.Name = country.Name;
                existingCountry.CountryCode = country.CountryCode;
                existingCountry.Description = country.Description;

                _customServices.Update(existingCountry);

                return Ok("Country updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the country: {ex.Message}");
            }
        }

        [HttpDelete(nameof(DeleteCountry) + "/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var country = await _customServices.Get(id);
                if (country == null)
                {
                    return NotFound("Country not found.");
                }

                _customServices.Delete(country);

                return Ok("Country deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the country: {ex.Message}");
            }
        }
    }
}