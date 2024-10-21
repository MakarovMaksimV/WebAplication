using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Abstraction;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
		{
            _productRepo = productRepo;
		}


		[HttpPost ("AddProduct")]
		public ActionResult<int> AddProduct(ProductDto productDto)
		{
            try
            {
                var id = _productRepo.AddProduct(productDto);
                return Ok(id);

            }
            catch(Exception)
            {
                return StatusCode(409);
            }
            
            //using (ProductContext storageContext = new ProductContext())
            //{
            //	if(storageContext.Products.Any(x=>x.Name.Contains(name)))
            //	{
            //		return StatusCode(409);
            //	}

            //	Product product = new Product() { Name = name, Discription = discription, Price = price };
            //	storageContext.Products.Add(product);
            //	storageContext.SaveChanges();
            //             return Ok(product.Id);
            //         }
        }

        [HttpGet("GetProduct")]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {

            return Ok(_productRepo.GetProduct());
    //        IEnumerable<Product> list;
    //        using (ProductContext storageContext = new ProductContext())
    //        {
				//list = storageContext.Products.
				//	Select(p => new Product { Name = p.Name, Discription = p.Discription, Price = p.Price }).ToList();
    //            return Ok(list);
    //        }
            
        }

        [HttpPost("DeleteProduct")]
        public ActionResult<int> DeleteProduct(int id)
        {
            using (ProductContext storageContext = new ProductContext())
            {
                if (storageContext.Products.Any(x => x.Id == id))
                {
                    var deleteproduct = storageContext.Products.Find(id);
                    if (deleteproduct != null)
                    {
                        storageContext.Products.Remove(deleteproduct);
                        storageContext.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
                else
                {
                    return StatusCode(409);
                }
            }
        }
    }
}

