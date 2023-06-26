using AutoMapper;
using LN.Contracts.Models;
using LN.Contracts.Service;
using LN.Core.Entities;

namespace LN.Contracts.Profiles
{
    public class UserProfile:Profile
    {
  
      

        public UserProfile()
        {
            CreateMap<UserCreateDto, UserEntity>()
                .ForMember(_ => _.SecondName, o => o.MapFrom(_ => _.SecondName))
                .ForMember(_ => _.FirstName, o => o.MapFrom(_ => _.FirstName))
                .ForMember(_ => _.City, o => o.MapFrom(_ => _.City))
                .ForMember(_ => _.Email, o => o.MapFrom(_ => _.Email))
                .ForMember(_ => _.Hobbies, o => o.MapFrom(_ => _.Hobbies))
                .ForMember(_ => _.Old, o => o.MapFrom(_ => _.Old));
                
            CreateMap<UserEntity, UserCreateDto>();

            CreateMap<UserEntity, UserViewDto>();
        }

    }
}
