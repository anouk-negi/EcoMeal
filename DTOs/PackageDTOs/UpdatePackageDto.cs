using System.ComponentModel.DataAnnotations;
namespace EcoMeal.DTOs.PackageDTOs
{
    public class UpdatePackageDto
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
        public float Price { get; set; }
        public int Quantity { get; set; } = 1;
        public string? PickUpStart { get; set; }
        public string? PickUpEnd { get; set; }
        [MaxLength(255, ErrorMessage = "Image URL cannot exceed 255 characters.")]
        public string? ImageURL { get; set; }
    }
}
