using System;

namespace EcoMeal.Data.Entities
{
	public class BusinessType
	{
		public Guid ID { get; set; }
		public string? Name { get; set; }
		public ICollection<Business> Businesses { get; } = new List<Business>();
	}
}