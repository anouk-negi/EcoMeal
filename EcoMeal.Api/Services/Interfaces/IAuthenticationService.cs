using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Dtos;
using Microsoft.AspNetCore.Identity.Data;

namespace EcoMeal.Api.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateToken(User user);
        Task<AuthResultDto> LoginAsync (LoginRequestDto loginRequest);
        Task<AuthResultDto> RegisterAsync (RegisterRequestDto registerRequest);
    }
}
