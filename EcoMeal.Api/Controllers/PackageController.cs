using EcoMeal.Api.Dtos;
using EcoMeal.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageGetDto>>> GetAll(
            [FromQuery] Guid? businessId,
            [FromQuery] Guid? packageTypeId,
            [FromQuery] bool onlyAvailable = false)
        {
            var items = await _packageService.GetAllAsync(businessId, packageTypeId, onlyAvailable);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageGetDto>> GetById(Guid id)
        {
            var item = await _packageService.GetByIdAsync(id);
            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles="Admin,Business")]
        public async Task<ActionResult<PackageGetDto>> Create([FromBody] PackagePostDto dto)
        {
            try
            {
                var created = await _packageService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.ID }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Business")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PackagePostDto dto)
        {
            try
            {
                var updated = await _packageService.UpdateAsync(id, dto);
                return updated ? NoContent() : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Business")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _packageService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}