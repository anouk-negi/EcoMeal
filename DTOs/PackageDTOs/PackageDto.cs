namespace EcoMeal.DTOs.PackageDTOs
{
    public class PackageDto
    {
        public Guid ID { get; set; }
        public Guid BusinessID { get; set; }
        public Guid PackageTypeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string? PickUpStart { get; set; }
        public string? PickUpEnd { get; set; }
        public string? ImageURL { get; set; }
    }
}
