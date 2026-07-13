using EcoMeal.Data.Entities;
using EcoMeal.DTOs.BusinessDTOs;

namespace EcoMeal.Repository
{
    public interface IBusinessRepository
    {
        Task<List<BusinessDto>> GetAllBusinessesAsync();
        Task<BusinessDto> GetbyGUIDAsync(Guid BusinessGUID);
        Task<BusinessDto> AddAsync(CreateBusinessDto businessDto);
        Task<BusinessDto> UpdateAsync(Guid guid, UpdateBusinessDto businessDto);
        Task<bool> DeleteAsync(Guid guid);
    }
}
