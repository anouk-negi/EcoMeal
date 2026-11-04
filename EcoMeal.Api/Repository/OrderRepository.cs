using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcoMealDbContext context)
            : base(context)
        {
        }
    }
}
