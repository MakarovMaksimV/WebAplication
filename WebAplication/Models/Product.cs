using System;
namespace WebAplication.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Discription { get; set; }
        public int? ProductGroupId { get; set; }
        public virtual ProductGroup? ProductGroup { get; set; }
		public virtual List<Storage> Storages { get; set; }

        public Product()
		{
		}
	}
}

