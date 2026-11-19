using System.ComponentModel.DataAnnotations;

namespace EcoMeal.Api.Dtos
{
    public class PackagePostDto
    {
        [Required]
        public Guid BusinessID { get; set; }

        [Required]
        public Guid PackageTypeID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public float? Price { get; set; }

        [Required]
        [Range(0, 100000)]
        public int? AvailableQuantitity { get; set; }

        [Required]
        public DateTime PickupStart { get; set; }

        [Required]
        public DateTime PickupEnd { get; set; }

        [Url]
        public string? ImageURL { get; set; }
    }
}