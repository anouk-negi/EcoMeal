using System;

namespace EcoMeal.Data.Entities
{
    public class Business
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public Guid BusinessTypeID { get; set; }

        public BusinessType Type { get; set; }

        public ICollection<Package> Packages { get; } = new List<Package>();
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}