using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Abstraction;
using WebAplication.Data;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Repo
{
	public class ProductGroupRepo : IProductGroupRepo
	{
        ProductContext storageContext = new ProductContext();
        private readonly IMapper _mapper;

        public ProductGroupRepo(ProductContext storageContext, IMapper _mapper)
        {
            this.storageContext = storageContext;
            this._mapper = _mapper;
        }

        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (storageContext.ProductsGroup.Any(x => x.Name == productGroupDto.Name))
            {
                throw new Exception("Группа уже есть в базе");
            }
            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            storageContext.ProductsGroup.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;
        }

        public ActionResult<int> DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }
    }
}

