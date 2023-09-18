using AutoMapper;
using Sample.Application.DTOs;
using Sample.Domain;
using Sample.Domain.Enums;

namespace Sample.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap()
                .ForMember(x => x.PhoneNumber, config => config.MapFrom(src => src.UserName))
                .ForMember(x => x.Status, config => config.MapFrom(src => Status.Active));
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ForMember(x => x.FullName, config => config.MapFrom(src => src.FirstName + " " + src.LastName));

        }
    }
}
