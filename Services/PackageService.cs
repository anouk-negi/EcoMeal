using EcoMeal.Components.Pages;
using EcoMeal.Data;
using EcoMeal.Data.Entities;
using EcoMeal.DTOs.PackageDTOs;
using EcoMeal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Services
{
    public class PackageService : IPackageRepository
    {
        private readonly EcoMealDbContext _context;

        public PackageService(EcoMealDbContext context)
        {
            _context = context;
        }

        public static PackageDto MapPackage(Package package)
        {
            return new PackageDto
            {

                BusinessID = package.BusinessID,
                PackageTypeID = package.PackageTypeID,
                Name = package.Name,
                Description = package.Description,
                Price = package.Price,
                Quantity = package.Quantity,
                PickUpStart = package.PickUpStart,
                PickUpEnd = package.PickUpEnd,
                ImageURL = package.ImageURL
            };
        }


        public async Task<List<PackageDto>> GetAllPackagesAsync()
        {
            var packagees = await _context.Packages
                .ToListAsync();
            return packagees.Select(MapPackage).ToList();

        }

        public async Task<PackageDto> GetbyGUIDAsync(Guid packageGUID)
        {
            var packagees = await _context.Packages
                .ToListAsync();

            var package = packagees.FirstOrDefault(b => b.ID == packageGUID);

            if (package == null) { return null; }

            return MapPackage(package);
        }
        public async Task<PackageDto> AddAsync(CreatePackageDto packageDto)
        {
            var package = new Package
            {
                BusinessID = packageDto.BusinessID,
                PackageTypeID = packageDto.PackageTypeID,
                Name = packageDto.Name,
                Description = packageDto.Description,
                Price = packageDto.Price,
                Quantity = packageDto.Quantity,
                PickUpStart = packageDto.PickUpStart,
                PickUpEnd = packageDto.PickUpEnd,
                ImageURL = packageDto.ImageURL
            };

            _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();

            return MapPackage(package);
        }
        public async Task<PackageDto> UpdateAsync(Guid guid, UpdatePackageDto packageDto)
        {
            var packagees = await _context.Packages
                     .ToListAsync();

            var package = packagees.FirstOrDefault(b => b.ID == guid);

            package.BusinessID = packageDto.BusinessID;
            package.PackageTypeID = packageDto.PackageTypeID;
            package.Name = packageDto.Name;
            package.Description = packageDto.Description;
            package.Price = packageDto.Price;
            package.Quantity = packageDto.Quantity;
            package.PickUpStart = packageDto.PickUpStart;
            package.PickUpEnd = packageDto.PickUpEnd;
            package.ImageURL = packageDto.ImageURL;


            _context.Update(package);
            await _context.SaveChangesAsync();

            return MapPackage(package);
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {

            var packagees = await _context.Packages
                .ToListAsync();

            var package = packagees.FirstOrDefault(b => b.ID == guid);

            if (package == null) { return false; }

            _context.Packages.Remove(package);
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
