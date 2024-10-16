using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Models;

namespace WebAplication.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		public ProductController()
		{
		}
		[HttpPost]
		public ActionResult<int> AddProduct(string name, string discription, double price)
		{
			using (ProductContext storageContext = new ProductContext())
			{
				if(storageContext.Products.Any(x=>x.Name.Contains(name)))
				{
					return StatusCode(409);
				}

				Product product = new Product() { Name = name, Discription = discription, Price = price };
				storageContext.Products.Add(product);
				storageContext.SaveChanges();
                return Ok(product.Id);
            }
		}

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            using (ProductContext storageContext = new ProductContext())
            {
				var list = storageContext.Products.
					Select(p => new Product { Name = p.Name, Discription = p.Discription, Price = p.Price });
				return Ok(list);
            }
        }

    }
}

