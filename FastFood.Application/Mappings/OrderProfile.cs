using AutoMapper;
using FastFood.Application.DTOs;
using FastFood.Domain.Entities;
using FastFood.Domain.Enums;

namespace FastFood.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderRequest, Order>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => EnumOrderStatus.Recebido));
        }
    }
}
