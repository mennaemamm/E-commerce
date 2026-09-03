using AutoMapper;
using Ecommerce.Application.DTOs.ProductDtos;
using Ecommerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));
        }
    }
}
