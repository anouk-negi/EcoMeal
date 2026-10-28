namespace EcoMeal.Api.Data.Entities
{
    public class Business
    {
        public Guid ID { get; set; }
        public Guid BusinessTypeID { get; set; }
        public Guid OwnerID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set;  }
        public string? ImageURL { get; set;  }
        
        public BusinessType? Type { get; set;  }
        public User? Owner { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Package> Packages { get; } = new List<Package>();

    }
}
