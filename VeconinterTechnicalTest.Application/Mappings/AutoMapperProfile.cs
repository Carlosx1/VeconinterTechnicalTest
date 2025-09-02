using AutoMapper;
using VeconinterTechnicalTest.Application.DTOs;
using VeconinterTechnicalTest.Domain.Entities;

namespace VeconinterTechnicalTest.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Client mappings
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.SubClients, opt => opt.MapFrom(src => src.SubClients));
                
        CreateMap<ClientDto, Client>()
            .ForMember(dest => dest.SubClients, opt => opt.Ignore());
            
        // SubClient mappings
        CreateMap<SubClient, SubClientDto>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name));
                
        CreateMap<SubClientDto, SubClient>()
            .ForMember(dest => dest.Client, opt => opt.Ignore());
            
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }

}