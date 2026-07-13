using EcoMeal.Data;
using EcoMeal.Data.Entities;
using EcoMeal.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using EcoMeal.DTOs.BusinessDTOs;

namespace EcoMeal.Services
{
    public class BusinessService : IBusinessRepository
    {
        private readonly EcoMealDbContext _context;

        public BusinessService(EcoMealDbContext context)
        {
            _context = context;
        }

        public static BusinessDto MapBusiness(Business business)
        {
            return new BusinessDto
            {
                ID = business.ID,
                Name = business.Name,
                Address = business.Address,
                Description = business.Description,
                ImageURL = business.ImageURL,
                BusinessTypeID = business.BusinessTypeID
            };
        }


        public async Task<List<BusinessDto>> GetAllBusinessesAsync()
        {
            var businesses = await _context.Businesses
                .Include(b => b.Type)
                .ToListAsync();
            return businesses.Select(MapBusiness).ToList();

        }

        public async Task<BusinessDto> GetbyGUIDAsync(Guid businessGUID)
        {
            var businesses = await _context.Businesses
                .Include(b => b.Type)
                .ToListAsync();

            var business = businesses.FirstOrDefault(b => b.ID == businessGUID);

            if (business == null) { return null; }

            return MapBusiness(business);
        }
        public async Task<BusinessDto> AddAsync(CreateBusinessDto businessDto)
        {
            var business = new Business
            {
                Name = businessDto.Name,
                Description = businessDto.Description,
                Address = businessDto.Address,
                ImageURL = businessDto.ImageURL,
                BusinessTypeID = businessDto.BusinessTypeID,
            };

            _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();

            return MapBusiness(business);
        }
        public async Task<BusinessDto> UpdateAsync(Guid guid, UpdateBusinessDto businessDto)
        {
            var businesses = await _context.Businesses
                .Include(b => b.Type)
                .ToListAsync();

            var business = businesses.FirstOrDefault(b => b.ID == guid);

            business.Name = businessDto.Name;
            business.Description = businessDto.Description;
            business.Address = businessDto.Address;
            business.ImageURL = businessDto.ImageURL;
            business.BusinessTypeID = businessDto.BusinessTypeID;


            _context.Update(business);
            await _context.SaveChangesAsync();

            return MapBusiness(business);
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {

            var businesses = await _context.Businesses
                .Include(b => b.Type)
                .ToListAsync();

            var business = businesses.FirstOrDefault(b => b.ID == guid);

            if (business == null) { return false; }

            _context.Businesses.Remove(business);
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
