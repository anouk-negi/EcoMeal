using System.ComponentModel.DataAnnotations;
namespace EcoMeal.DTOs.OrderDTOs
{
    public class UpdateOrderDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Business ID is required.")]
        public Guid BusinessID { get; set; }
        public Guid StatusId { get; set; }
        public int OrderNumber { get; set; }
    }
}
