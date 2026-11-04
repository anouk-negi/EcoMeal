using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EcoMealDbContext context)
           : base(context)
        {
        }
    }
}
