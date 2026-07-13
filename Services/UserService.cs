using EcoMeal.Components.Pages;
using EcoMeal.Data;
using EcoMeal.Data.Entities;
using EcoMeal.DTOs.UserDTOs;
using EcoMeal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Services
{
    public class UserService : IUserRepository
    {
        private readonly EcoMealDbContext _context;

        public UserService(EcoMealDbContext context)
        {
            _context = context;
        }

        public static UserDto MapUser(User user)
        {
            return new UserDto
            {
                RoleID = user.RoleID,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name  
            };
        }


        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var useres = await _context.Users
                .ToListAsync();
            return useres.Select(MapUser).ToList();

        }

        public async Task<UserDto> GetbyGUIDAsync(Guid userGUID)
        {
            var useres = await _context.Users
                .ToListAsync();

            var user = useres.FirstOrDefault(b => b.ID == userGUID);

            if (user == null) { return null; }

            return MapUser(user);
        }
        public async Task<UserDto> AddAsync(CreateUserDto userDto)
        {
            var user = new User
            {
                RoleID = userDto.RoleID,
                Email = userDto.Email,
                Password = userDto.Password,
                Name = userDto.Name
            };

            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return MapUser(user);
        }
        public async Task<UserDto> LogInAsync(Guid guid, LogInDto userDto)
        {
            var useres = await _context.Users
                     .ToListAsync();

            var user = useres.FirstOrDefault(b => b.ID == guid);

            user.Email = userDto.Email;
            user.Password = userDto.Password;


            _context.Update(user);
            await _context.SaveChangesAsync();

            return MapUser(user);
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {

            var useres = await _context.Users
                .ToListAsync();

            var user = useres.FirstOrDefault(b => b.ID == guid);

            if (user == null) { return false; }

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
