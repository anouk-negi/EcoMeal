using EcoMeal.DTOs.UserDTOs;
namespace EcoMeal.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetbyGUIDAsync(Guid guid);
        Task<UserDto> AddAsync(CreateUserDto userDto);
        Task<UserDto> LogInAsync(Guid guid, LogInDto userDto);
        Task<bool> DeleteAsync(Guid guid);
    }
}
