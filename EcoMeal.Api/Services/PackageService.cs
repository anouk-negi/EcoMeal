using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Dtos;
using EcoMeal.Api.Services.Interfaces;
using EcoMeal.Api.UnitOfWork;

namespace EcoMeal.Api.Services
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PackageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PackageGetDto>> GetAllAsync(
            Guid? businessId = null,
            Guid? packageTypeId = null,
            bool onlyAvailable = false)
        {
            var packages = await _unitOfWork.PackageRepository.GetAllAsync();
            var businesses = (await _unitOfWork.BusinessRepository.GetAllAsync())
                .ToDictionary(b => b.ID, b => b.Name);
            var packageTypes = (await _unitOfWork.PackageTypeRepository.GetAllAsync())
                .ToDictionary(t => t.ID, t => t.Name);

            var query = packages.AsEnumerable();

            if (businessId.HasValue)
                query = query.Where(p => p.BusinessID == businessId.Value);

            if (packageTypeId.HasValue)
                query = query.Where(p => p.PackageTypeID == packageTypeId.Value);

            if (onlyAvailable)
                query = query.Where(p => (p.AvailableQuantitity ?? 0) > 0 && p.PickupEnd >= DateTime.UtcNow);

            return query.Select(p => MapToGetDto(
                p,
                businesses.GetValueOrDefault(p.BusinessID),
                packageTypes.GetValueOrDefault(p.PackageTypeID))).ToList();
        }

        public async Task<PackageGetDto?> GetByIdAsync(Guid id)
        {
            var package = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (package is null)
                return null;

            var business = await _unitOfWork.BusinessRepository.GetByIdAsync(package.BusinessID);
            var packageType = await _unitOfWork.PackageTypeRepository.GetByIdAsync(package.PackageTypeID);

            return MapToGetDto(package, business?.Name, packageType?.Name);
        }

        public async Task<PackageGetDto> CreateAsync(PackagePostDto dto)
        {
            if (dto.PickupEnd <= dto.PickupStart)
                throw new ArgumentException("PickupEnd must be later than PickupStart.");

            var entity = new Package
            {
                ID = Guid.NewGuid(),
                BusinessID = dto.BusinessID,
                PackageTypeID = dto.PackageTypeID,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                AvailableQuantitity = dto.AvailableQuantitity,
                PickupStart = dto.PickupStart,
                PickupEnd = dto.PickupEnd,
                ImageURL = dto.ImageURL
            };

            await _unitOfWork.PackageRepository.InsertAsync(entity);
            await _unitOfWork.Save();

            var business = await _unitOfWork.BusinessRepository.GetByIdAsync(entity.BusinessID);
            var packageType = await _unitOfWork.PackageTypeRepository.GetByIdAsync(entity.PackageTypeID);

            return MapToGetDto(entity, business?.Name, packageType?.Name);
        }

        public async Task<bool> UpdateAsync(Guid id, PackagePostDto dto)
        {
            if (dto.PickupEnd <= dto.PickupStart)
                throw new ArgumentException("PickupEnd must be later than PickupStart.");

            var existing = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (existing is null)
                return false;

            existing.BusinessID = dto.BusinessID;
            existing.PackageTypeID = dto.PackageTypeID;
            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Price = dto.Price;
            existing.AvailableQuantitity = dto.AvailableQuantitity;
            existing.PickupStart = dto.PickupStart;
            existing.PickupEnd = dto.PickupEnd;
            existing.ImageURL = dto.ImageURL;

            _unitOfWork.PackageRepository.UpdateAsync(existing);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (existing is null)
                return false;

            _unitOfWork.PackageRepository.DeleteAsync(id);
            await _unitOfWork.Save();
            return true;
        }

        private static PackageGetDto MapToGetDto(
            Package p,
            string? businessName = null,
            string? packageTypeName = null) => new()
            {
                ID = p.ID,
                BusinessID = p.BusinessID,
                BusinessName = businessName ?? p.Business?.Name,
                PackageTypeID = p.PackageTypeID,
                PackageTypeName = packageTypeName ?? p.Type?.Name,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                AvailableQuantitity = p.AvailableQuantitity,
                PickupStart = p.PickupStart,
                PickupEnd = p.PickupEnd,
                ImageURL = p.ImageURL
            };
    }
}