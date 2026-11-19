using EcoMeal.Api.Dtos;
using EcoMeal.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessesController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses()
        {
            try
            {
                var businesses = await _businessService.GetAllBusinesses();
                if (ModelState.IsValid)
                {
                    return Ok(businesses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (NullReferenceException)
            {
                return NotFound(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBusinessAsync([FromBody] BusinessPostDto business)
        {
            await _businessService.AddBusinessAsync(business);
            return Ok();
        }
    }
}
