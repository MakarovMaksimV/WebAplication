using System;
using AutoMapper;
using WebAplication.Dto;
using WebAplication.Models;

namespace WebAplication.Mapper
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }
	}
}

