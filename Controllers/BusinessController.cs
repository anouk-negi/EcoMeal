using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcoMeal.Services;
using EcoMeal.Data.Entities;
using Blazorise;
using EcoMeal.DTOs.BusinessDTOs;
namespace EcoMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly BusinessService _businessService;

        public BusinessController(BusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BusinessDto>>> GetBusiness()
        {
            try
            {
                var businesses = await _businessService.GetAllBusinessesAsync();

                if (businesses == null || businesses.Count == 0)
                {
                    return NotFound("No businesses found.");
                }

                return Ok(businesses);
            }catch (Exception ex){
                return StatusCode(500, "Could not find businesses: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BusinessDto>> AddBusiness(CreateBusinessDto businessDto)
        {
            try
            {
                var business = await _businessService.AddAsync(businessDto);
                return CreatedAtAction(nameof(GetBusiness), new { id = business.ID }, business);
            }
            catch (Exception ex) {
                return StatusCode(500, "Could not add business: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BusinessDto>> UpdateBusiness(Guid id, UpdateBusinessDto businessDto)
        {
            try
            {
                var business = await _businessService.UpdateAsync(id, businessDto);
                return Ok(business);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Could not update business: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessDto>> DeleteBusiness(Guid id)
        {
            try
            {
                var business = await _businessService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Could not update business: " + ex.Message);
            }
        }

    }
}
