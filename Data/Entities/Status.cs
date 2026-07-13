using System;

namespace EcoMeal.Data.Entities
{
    public class Status
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}