using System.ComponentModel.DataAnnotations;

namespace EcoMeal.DTOs.BusinessDTOs
{
    public class UpdateBusinessDto
    {
        [Required(ErrorMessage = "Business name is required.")]
        [MaxLength(255, ErrorMessage = "Business name cannot exceed 255 characters.")]
        public string? Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }

        [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string? Address { get; set; }

        public string? ImageURL { get; set; }

        public Guid BusinessTypeID { get; set; }
    }
}
