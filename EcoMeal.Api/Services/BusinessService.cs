using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Dtos;
using EcoMeal.Api.Repository.Interfaces;
using EcoMeal.Api.Services.Interfaces;

namespace EcoMeal.Api.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<IEnumerable<BusinessGetDto>> GetAllBusinesses()
        {
            var businesses = await _businessRepository.GetAllAsync();

            if(businesses == null)
            {
                throw new NullReferenceException("No available businesses");
            }

            var dtos = businesses
                .Select(b => new BusinessGetDto
                {
                    ID = b.ID,
                    Name = b.Name,
                    Description = b.Description,
                    Address = b.Address,
                    ImageURL = b.ImageURL,
                    BusinessTypeID = b.BusinessTypeID
                })
                .ToList();

            return dtos;
        }
        public async Task AddBusinessAsync(BusinessPostDto businessDto)
        {
            var business = new Business()
            {
                OwnerID = businessDto.OwnerID,
                Name = businessDto.Name,
                Description = businessDto.Description,
                Address = businessDto.Address,
                ImageURL = businessDto.ImageURL,
                BusinessTypeID = businessDto.BusinessType
            };

            await _businessRepository.InsertAsync(business);
        }
    }
}
