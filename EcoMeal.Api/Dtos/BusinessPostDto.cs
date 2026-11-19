namespace EcoMeal.Api.Dtos
{
    public class BusinessPostDto
    {
        public Guid OwnerID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public Guid BusinessType { get; set; }
    }
}
