using AutoMapper;
using Ecommerce.Application.DTOs.BasketsDtos;
using Ecommerce.Domain.Entities.Baskets;

namespace Ecommerce.Application.Profiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
