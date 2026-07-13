using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcoMeal.Services;
using EcoMeal.Data.Entities;
using Blazorise;
using EcoMeal.DTOs.UserDTOs;
namespace EcoMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _businessService;

        public UserController(UserService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUser()
        {
            try
            {
                var businesses = await _businessService.GetAllUsersAsync();

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
        public async Task<ActionResult<UserDto>> AddUser(CreateUserDto businessDto)
        {
            try
            {
                var business = await _businessService.AddAsync(businessDto);
                return CreatedAtAction(nameof(GetUser), new { id = business.ID }, business);
            }
            catch (Exception ex) {
                return StatusCode(500, "Could not add business: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> LogInUser(Guid id, LogInDto businessDto)
        {
            try
            {
                var business = await _businessService.LogInAsync(id, businessDto);
                return Ok(business);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Could not update business: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
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
