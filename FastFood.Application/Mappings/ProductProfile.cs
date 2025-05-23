using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FastFood.Application.DTOs;

namespace FastFood.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));

            CreateMap<Product, ProductResponse>();
        }
    }
}
