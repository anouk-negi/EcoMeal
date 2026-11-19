namespace EcoMeal.Api.Dtos
{
    public class BusinessGetDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public Guid BusinessTypeID { get; set; }
    }
}
