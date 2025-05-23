using AutoMapper;
using FastFood.Application.DTOs;

namespace FastFood.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Product, ProductResponse>();
        }
    }
}
