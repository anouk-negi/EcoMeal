using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Repository;
using EcoMeal.Api.Repository.Interfaces;
using EcoMeal.Api.Services.Interfaces;

namespace EcoMeal.Api.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _roleRepository.GetByNameAsync(roleName);
        }
    }
}
