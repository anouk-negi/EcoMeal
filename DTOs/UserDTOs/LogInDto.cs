using System.ComponentModel.DataAnnotations;

namespace EcoMeal.DTOs.UserDTOs
{
    public class LogInDto
    {
        [Required(ErrorMessage = "Email addressis required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; } = null!;
    }
}
