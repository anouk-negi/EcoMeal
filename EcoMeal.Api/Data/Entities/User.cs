using System.ComponentModel.DataAnnotations;

namespace EcoMeal.Api.Data.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
