namespace EcoMeal.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid BusinessID { get; set; }
        public Guid StatusId { get; set; }
        public int OrderNumber { get; set; }
    }
}
