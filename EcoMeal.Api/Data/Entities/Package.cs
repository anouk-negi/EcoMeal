using System.Diagnostics.Contracts;

namespace EcoMeal.Api.Data.Entities
{
    public class Package
    {
        public Guid ID { get; set; }
        public Guid BusinessID { get; set; }
        public Guid PackageTypeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? AvailableQuantitity { get; set; }
        public DateTime PickupStart { get; set; }
        public DateTime PickupEnd { get; set; }
        public string? ImageURL { get; set; }

        public Business? Business { get; set; }
        public PackageType? Type { get; set; }
        public ICollection<OrderPackage> Orders { get; } = new List<OrderPackage>();

    }
}
