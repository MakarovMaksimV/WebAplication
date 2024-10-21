using System;
using WebAplication.Models;

namespace WebAplication.OutModels
{
	public class ProductOutModel : Product
	{
		public ProductOutModel()
		{
		}

        public double Price { get; set; }
        public int? ProductGroupId { get; set; }
        public string Discription { get; set; }
    }
}

