using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Abstraction
{
	public interface IProductGroupRepo
	{
        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto);
        public ActionResult<int> DeleteProductGroup(ProductGroupDto productGroupDto);

    }
}

