namespace EcoMeal.Api.Dtos
{
    public class PackageGetDto
    {
        public Guid ID { get; set; }
        public Guid BusinessID { get; set; }
        public string? BusinessName { get; set; }
        public Guid PackageTypeID { get; set; }
        public string? PackageTypeName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? AvailableQuantitity { get; set; }
        public DateTime PickupStart { get; set; }
        public DateTime PickupEnd { get; set; }
        public string? ImageURL { get; set; }
    }
}