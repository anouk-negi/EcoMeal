using System;

namespace EcoMeal.Data.Entities
{
    public class Package
    {
        public Guid ID { get; set; }
        public Guid BusinessID { get; set; }
        public Guid PackageTypeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string? PickUpStart { get; set; }
        public string? PickUpEnd { get; set; }
        public string? ImageURL { get; set; }

        public Business Business { get; set; }

        public PackageType Type { get; set; }

        public ICollection<OrderPackage> Orders { get; } = new List<OrderPackage>();
    }
}