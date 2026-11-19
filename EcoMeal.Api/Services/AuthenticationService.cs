using EcoMeal.Api.Data.Entities;
using EcoMeal.Api.Dtos;
using EcoMeal.Api.Repository.Interfaces;
using EcoMeal.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcoMeal.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRoleRepository _roleRepository;

        public AuthenticationService(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IRoleRepository roleRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager  = signInManager;
            _roleRepository = roleRepository;
        }

        public async Task<string> GenerateToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var role = await _roleRepository.GetByIdAsync(user.RoleID);
            if (role == null)
            {
                throw new InvalidOperationException(
                    "User does not have a valid role."
                );
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, role.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<AuthResultDto> LoginAsync (LoginRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "Invalid email or password"
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            
            if (!result.Succeeded)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "Invalid email or password"
                };
            }

            var userRole = await _roleRepository.GetByIdAsync(user.RoleID);

            if (userRole == null || userRole.Name != request.Role)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "You cannot log in using this account type."
                };
            }

            var token = await GenerateToken(user);
            return new AuthResultDto
            {
                Succeeded = true,
                Token = token,
                User = new { user.Id, user.Email, user.Name, Role = userRole.Name },
            };
        }

        public async Task<AuthResultDto> RegisterAsync(RegisterRequestDto request)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);

            if (userExists != null)
                return new AuthResultDto { Succeeded = false, ErrorMessage = "User already exists" };

            var role = await _roleRepository.GetByNameAsync(request.Role);

            if (role == null)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "Invalid role specified"
                };
            }

            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                RoleID = role.ID
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new AuthResultDto { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
            
            var token = await GenerateToken(user);

            return new AuthResultDto { Succeeded = true, Token = token, User = new { user.Id, user.Email, user.Name } };
        }
    }
}
