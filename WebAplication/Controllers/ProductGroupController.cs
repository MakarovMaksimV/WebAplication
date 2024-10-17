using System;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Data;
using WebAplication.Models;

namespace WebAplication.Controllers
{
	public class ProductGroupController : ControllerBase
	{
		public ProductGroupController()
		{
		}

        [HttpPost("AddGroup")]
        public ActionResult<int> AddProductGroup(string name, string discription)
        {
            using (ProductContext storageContext = new ProductContext())
            {
                if (storageContext.ProductsGroup.Any(x => x.Name.Contains(name)))
                {
                    return StatusCode(409);
                }

                ProductGroup productGroup = new ProductGroup() { Name = name, Discription = discription};
                storageContext.ProductsGroup.Add(productGroup);
                storageContext.SaveChanges();
                return Ok(productGroup.Id);
            }
        }

        [HttpPost("DeleteGroup")]
        public ActionResult<int> DeleteProductGroup(int id)
        {
            using (ProductContext storageContext = new ProductContext())
            {
                if (storageContext.ProductsGroup.Any(x => x.Id == id))
                {
                    var deletegroup = storageContext.ProductsGroup.Find(id);
                    if(deletegroup != null)
                    {
                        storageContext.ProductsGroup.Remove(deletegroup);
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

