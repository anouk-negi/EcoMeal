using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.Api.Services.Interfaces
{
    public interface IBusinessService
    {
        Task<IEnumerable<BusinessGetDto>> GetAllBusinesses();
        Task AddBusinessAsync(BusinessPostDto businessDto);
    }
}
