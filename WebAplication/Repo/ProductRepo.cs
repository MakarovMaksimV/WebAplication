using WebAplication;
using Microsoft.AspNetCore.Mvc;
using WebAplication.Abstraction;
using WebAplication.Models;
using WebAplication.Data;
using WebAplication.Dto;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace WebAplication.Repo
{
	public class ProductRepo : IProductRepo
	{
        ProductContext storageContext = new();
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

		public ProductRepo(ProductContext storageContext, IMapper _mapper, IMemoryCache memoryCache)
		{
            this.storageContext = storageContext;
            this._mapper = _mapper;
            this._memoryCache = memoryCache;
		}

        public int AddProduct(ProductDto productDto)
        {
            if (storageContext.Products.Any(x => x.Name == productDto.Name))
            {
                throw new Exception("Продукт уже есть в базе");
            }
            var entity = _mapper.Map<Product>(productDto);
            storageContext.Products.Add(entity);
            storageContext.SaveChanges();
            _memoryCache.Remove("products");
            return entity.Id;
        }

        public ActionResult<IEnumerable<ProductDto>> GetProduct()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto)) return listDto;
            listDto = storageContext.Products.
                    Select(_mapper.Map<ProductDto>).ToList();
            _memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));
            
            return listDto;
        }

        public ActionResult<int> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}

