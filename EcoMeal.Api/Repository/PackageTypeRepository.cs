using EcoMeal.Api.Data;
using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.Repository
{
    public class PackageTypeRepository : GenericRepository<PackageType>, IPackageTypeRepository
    {
        public PackageTypeRepository(EcoMealDbContext context)
            : base(context)
        {
        }
    }
}
