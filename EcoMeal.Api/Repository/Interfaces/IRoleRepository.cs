using EcoMeal.Api.Data.Entities;

namespace EcoMeal.Api.Repository.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetByNameAsync(string roleName);
    }
}
