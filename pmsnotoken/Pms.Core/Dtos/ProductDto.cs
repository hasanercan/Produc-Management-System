using System;
namespace Pms.Core.Dtos
{
	public class ProductDto:BaseDto
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

    }
}

