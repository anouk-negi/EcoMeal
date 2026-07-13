using System;

namespace EcoMeal.Data.Entities
{
    public class PackageType
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }

        public ICollection<Package> Packages { get; } = new List<Package>();
    }
}