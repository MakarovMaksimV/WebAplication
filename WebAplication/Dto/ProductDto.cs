using System;
using WebAplication.Models;

namespace WebAplication.Dto
{
	public class ProductDto
	{

        public string Name { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        public int? ProductGroupId { get; set; }



    }
}

