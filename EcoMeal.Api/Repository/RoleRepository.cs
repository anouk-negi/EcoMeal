using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Api.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(EcoMealDbContext context)
            : base(context)
        {
        }

        public async Task<Role> GetByNameAsync(string roleName)
        {
            return _context.Role
                .Where(r => r.Name == roleName)
                .FirstOrDefault();
        }
    }
}
