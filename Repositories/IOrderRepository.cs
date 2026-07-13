using EcoMeal.DTOs.BusinessDTOs;
using EcoMeal.DTOs.OrderDTOs;
namespace EcoMeal.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetbyGUIDAsync(Guid guid);
        Task<OrderDto> AddAsync(CreateOrderDto orderDto);
        Task<OrderDto> UpdateAsync(Guid guid, UpdateOrderDto orderDto);
        Task<bool> DeleteAsync(Guid guid);
    }

}
