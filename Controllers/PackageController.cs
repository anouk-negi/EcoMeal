using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcoMeal.Services;
using EcoMeal.Data.Entities;
using Blazorise;
using EcoMeal.DTOs.PackageDTOs;
namespace EcoMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _businessService;

        public PackageController(PackageService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PackageDto>>> GetPackage()
        {
            try
            {
                var businesses = await _businessService.GetAllPackagesAsync();

                if (businesses == null || businesses.Count == 0)
                {
                    return NotFound("No businesses found.");
                }

                return Ok(businesses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Could not find businesses: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PackageDto>> AddPackage(CreatePackageDto businessDto)
        {
            try
            {
                var business = await _businessService.AddAsync(businessDto);
                return CreatedAtAction(nameof(GetPackage), new { id = business.ID }, business);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Could not add business: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PackageDto>> UpdatePackage(Guid id, UpdatePackageDto businessDto)
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
        public async Task<ActionResult<PackageDto>> DeletePackage(Guid id)
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
