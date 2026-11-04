using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(EcoMealDbContext context)
            : base(context)
        {
        }
    }
}
