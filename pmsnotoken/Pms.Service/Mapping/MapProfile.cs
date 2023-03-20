using System;
using AutoMapper;
using Pms.Core;
using Pms.Core.Dtos;

namespace Pms.Service.Mapping
{
	public class MapProfile: Profile
	{
		public MapProfile()
		{
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();

        }
    }
}

