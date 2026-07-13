using EcoMeal.Data.Entities;

namespace EcoMeal.DTOs.BusinessDTOs
{
    public class BusinessDto
    {
            public Guid ID { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Address { get; set; }
            public string? ImageURL { get; set; }
            public Guid BusinessTypeID { get; set; }
    }
}
