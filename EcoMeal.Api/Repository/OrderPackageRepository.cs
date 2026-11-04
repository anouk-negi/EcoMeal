using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class OrderPackageRepository : GenericRepository<OrderPackage>, IOrderPackageRepository
    {
        public OrderPackageRepository(EcoMealDbContext context)
            : base(context)
        {
        }
    }
}
