using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Abstraction
{
	public interface IProductGroupRepo
	{
        [HttpPost("AddGroup")]
        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto);

        [HttpPost("DeleteGroup")]
        public ActionResult<int> DeleteProductGroup(int id);

    }
}

