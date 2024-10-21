using System;
using WebAplication.Models;

namespace WebAplication.Dto
{
	public class ProductGroupDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}

