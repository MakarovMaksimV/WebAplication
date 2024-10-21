using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Abstraction
{
	public interface IProductRepo
	{
        public int AddProduct(ProductDto productDto);
        public ActionResult<IEnumerable<ProductDto>> GetProduct();
        public ActionResult<int> DeleteProduct(int id);
    }
}

