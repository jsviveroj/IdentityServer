using AutoMapper;
using IdentityServerApi.Dtos;
using IdentityServerApi.Models;

namespace IdentityServerApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
