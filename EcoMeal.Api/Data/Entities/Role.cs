namespace EcoMeal.Api.Data.Entities
{
    public class Role
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }

        public ICollection<User> Users { get;} = new List<User>();
    }
}
