using System;

namespace EcoMeal.Data.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        public Role? Role { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}