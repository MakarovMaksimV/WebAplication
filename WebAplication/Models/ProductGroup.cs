using System;
namespace WebAplication.Models
{
	public class ProductGroup
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Discription { get; set; }
		public virtual List<Product> Products {get; set;}

        public ProductGroup()
		{
		}
	}
}

