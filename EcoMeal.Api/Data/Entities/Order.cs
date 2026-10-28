namespace EcoMeal.Api.Data.Entities
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid BusinessID { get; set; }
        public Guid StatusID { get; set; }
        public int OrderNumber { get; set; }

        public User? User { get; set; }
        public Business? Business { get; set;  }
        public Status? Status { get; set; }
        public ICollection<OrderPackage> Packages { get; } = new List<OrderPackage>();
    }
}
