namespace EcoMeal.Api.Data.Entities
{
    public class OrderPackage
    {
        public Guid OrderID { get; set; }
        public Guid PackageID { get; set;   }
        public int Quantitiy { get; set;  }

        public Order? Order { get; set;  }
        public Package? Package { get; set; }

    }
}
