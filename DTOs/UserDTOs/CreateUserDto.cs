using System.ComponentModel.DataAnnotations;
namespace EcoMeal.DTOs.UserDTOs
{
    public class CreateUserDto
    {

        public Guid RoleID { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password cannot exceed 255 characters.")]
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
