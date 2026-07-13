using System.ComponentModel.DataAnnotations;
namespace EcoMeal.DTOs.PackageDTOs
{
    public class CreatePackageDto
    {
        [Required(ErrorMessage = "Business ID is required.")]
        public Guid BusinessID { get; set; }
        [Required(ErrorMessage = "PackageType ID is required.")]
        public Guid PackageTypeID { get; set; }
        [Required(ErrorMessage = "Package name is required.")]
        [MaxLength(255, ErrorMessage = "Package name cannot exceed 255 characters.")]
        public string? Name { get; set; }
        [MaxLength(255, ErrorMessage = "Package description cannot exceed 255 characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Package price is required.")]
        public float Price { get; set; }
        public int Quantity { get; set; } = 1;
        [Required(ErrorMessage = "Package pick-up start time is required.")]
        public string? PickUpStart { get; set; }
        [Required(ErrorMessage = "Package pick-up end time is required.")]
        public string? PickUpEnd { get; set; }
        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string? ImageURL { get; set; }
    }
}
