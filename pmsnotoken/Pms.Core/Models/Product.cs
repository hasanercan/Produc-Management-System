using System;
namespace Pms.Core
{
	public class Product:BaseEntity
	{
       
		public string Name { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

