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
    public class StateController : ControllerBase
    {
        private readonly ICustomServices<State> _customServices;

        public StateController(ICustomServices<State> customServices)
        {
            _customServices = customServices;
        }

        [HttpPost(nameof(CreateState))]
        public async Task<IActionResult> CreateState([FromBody] State states)
        {
            if (states == null)
            {
                return BadRequest("Invalid states data.");
            }

            try
            {
                _customServices.Insert(states);
                return new JsonResult("State created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the states: {ex.Message}");
            }
        }

        [HttpGet(nameof(GetAllStates))]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                var countries = await _customServices.GetAll();
                return new JsonResult(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving countries: {ex.Message}");
            }
        }

        [HttpGet(nameof(GetStateById) + "/{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            try
            {
                var states = await _customServices.Get(id);
                if (states == null)
                {
                    return NotFound("State not found.");
                }
                return new JsonResult(states);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the states: {ex.Message}");
            }
        }

        [HttpPut(nameof(UpdateState))]
        public async Task<IActionResult> UpdateState([FromBody] State states)
        {
            try
            {
                var existingState = await _customServices.Get(states.Id);
                if (existingState == null)
                {
                    return NotFound("State not found.");
                }

                existingState.Name = states.Name;
                existingState.StateCode = states.StateCode;
                existingState.Description = states.Description;

                _customServices.Update(existingState);

                return new JsonResult("State updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the states: {ex.Message}");
            }
        }

        [HttpDelete(nameof(DeleteState) + "/{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            try
            {
                var states = await _customServices.Get(id);
                if (states == null)
                {
                    return NotFound("State not found.");
                }

                _customServices.Delete(states);

                return new JsonResult("State deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the states: {ex.Message}");
            }
        }
    }
}