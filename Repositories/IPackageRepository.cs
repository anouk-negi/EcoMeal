using EcoMeal.DTOs.BusinessDTOs;
using EcoMeal.DTOs.PackageDTOs;
namespace EcoMeal.Repositories
{
    public interface IPackageRepository
    {
        Task<List<PackageDto>> GetAllPackagesAsync();
        Task<PackageDto> GetbyGUIDAsync(Guid guid);
        Task<PackageDto> AddAsync(CreatePackageDto packageDto);
        Task<PackageDto> UpdateAsync(Guid guid, UpdatePackageDto packageDto);
        Task<bool> DeleteAsync(Guid guid);
    }
}
