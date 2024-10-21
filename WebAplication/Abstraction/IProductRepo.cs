using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Abstraction
{
	public interface IProductRepo
	{
        [HttpPost("AddProduct")]
        public int AddProduct(ProductDto productDto);

        [HttpGet("GetProduct")]
        public ActionResult<IEnumerable<ProductDto>> GetProduct();

        [HttpPost("DeleteProduct")]
        public ActionResult<int> DeleteProduct(int id);
    }
}

