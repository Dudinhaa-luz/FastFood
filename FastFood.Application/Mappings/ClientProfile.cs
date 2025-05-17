using AutoMapper;
using FastFood.Application.DTOs;
using FastFood.Domain.Entities;

namespace FastFood.Application.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientRequest, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
