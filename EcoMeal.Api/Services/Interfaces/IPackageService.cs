using EcoMeal.Api.Dtos;

namespace EcoMeal.Api.Services.Interfaces
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageGetDto>> GetAllAsync(Guid? businessId = null, Guid? packageTypeId = null, bool onlyAvailable = false);
        Task<PackageGetDto?> GetByIdAsync(Guid id);
        Task<PackageGetDto> CreateAsync(PackagePostDto dto);
        Task<bool> UpdateAsync(Guid id, PackagePostDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
