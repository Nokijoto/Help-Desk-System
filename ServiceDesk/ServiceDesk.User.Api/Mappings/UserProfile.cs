using AutoMapper;
using ServiceDesk.User.CrossCutting.Dtos;


namespace ServiceDesk.User.Api.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User.Storage.Entities.User, UserDto>();
            CreateMap<CreateUserDto, User.Storage.Entities.User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<UpdateUserDto, User.Storage.Entities.User>();
        }

    }
}
