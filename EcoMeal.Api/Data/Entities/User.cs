using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcoMeal.Api.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid RoleID { get; set; }
        public string? Name { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
