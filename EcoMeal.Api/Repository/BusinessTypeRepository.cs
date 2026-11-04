using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class BusinessTypeRepository : GenericRepository<BusinessType>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(EcoMealDbContext context)
            : base(context)
        {
        }
    }
}
