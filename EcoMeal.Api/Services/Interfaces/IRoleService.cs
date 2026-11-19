using EcoMeal.Api.Data.Entities;

namespace EcoMeal.Api.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
