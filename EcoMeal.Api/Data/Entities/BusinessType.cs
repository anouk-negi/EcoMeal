namespace EcoMeal.Api.Data.Entities
{
    public class BusinessType
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }

        public ICollection<Business>? Businesses { get; set; }
    }
}
