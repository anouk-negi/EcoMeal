namespace EcoMeal.DTOs.UserDTOs
{
    public class UserDto
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
