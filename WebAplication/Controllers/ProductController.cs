using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAplication.Abstraction;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;
using WebAplication.OutModels;

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
        }

        [HttpGet("GetProduct")]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            return Ok(_productRepo.GetProduct());
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

        public FileContentResult GetProductsCSV()
        {
            using (ProductContext storageContext = new ProductContext())
            {
                var books = storageContext.Products.Select(x => new ProductOutModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Discription = x.Discription,
                    Price = x.Price,
                }).ToList();
                var content = GetCsv(books);
                return File(Encoding.UTF8.GetBytes(content), "text/csv", "products.csv");
            }
        }

        private string GetCsv(IEnumerable<ProductOutModel> products)
        {
            var sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id};{product.Name};{product.Discription};{product.Price}");
            }
            return sb.ToString();
        }
    }
}

