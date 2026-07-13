using EcoMeal.Components.Pages;
using EcoMeal.Data;
using EcoMeal.Data.Entities;
using EcoMeal.DTOs.OrderDTOs;
using EcoMeal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly EcoMealDbContext _context;

        public OrderService(EcoMealDbContext context)
        {
            _context = context;
        }

        public static OrderDto MapOrder(Order order)
        {
            return new OrderDto
            {
                UserID = order.UserID,
                BusinessID = order.BusinessID,
                StatusId = order.StatusId,
                OrderNumber = order.OrderNumber
            };
        }


        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orderes = await _context.Orders
                .ToListAsync();
            return orderes.Select(MapOrder).ToList();

        }

        public async Task<OrderDto> GetbyGUIDAsync(Guid orderGUID)
        {
            var orderes = await _context.Orders
                .ToListAsync();

            var order = orderes.FirstOrDefault(b => b.ID == orderGUID);

            if (order == null) { return null; }

            return MapOrder(order);
        }
        public async Task<OrderDto> AddAsync(CreateOrderDto orderDto)
        {
            var order = new Order
            {
                UserID = orderDto.UserID,
                BusinessID = orderDto.BusinessID,
                StatusId = orderDto.StatusId,
                OrderNumber = orderDto.OrderNumber
            };

            _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return MapOrder(order);
        }
        public async Task<OrderDto> UpdateAsync(Guid guid, UpdateOrderDto orderDto)
        {
            var orderes = await _context.Orders
                .ToListAsync();

            var order = orderes.FirstOrDefault(b => b.ID == guid);

            order.UserID = orderDto.UserID;
            order.BusinessID = orderDto.BusinessID;
            order.StatusId = orderDto.StatusId;
            order.OrderNumber = orderDto.OrderNumber;


            _context.Update(order);
            await _context.SaveChangesAsync();

            return MapOrder(order);
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {

            var orderes = await _context.Orders
                .ToListAsync();

            var order = orderes.FirstOrDefault(b => b.ID == guid);

            if (order == null) { return false; }

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
