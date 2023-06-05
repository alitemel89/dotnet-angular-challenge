using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Domain.Models;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserDto, User>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));


            CreateMap<PostDto, Post>()
            .ForMember(dest => dest.PostId, opt => opt.Ignore())
            .ForMember(dest => dest.Caption, opt => opt.MapFrom(src => src.Caption))
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                   {
                       UserId = Guid.Parse(src.UserId),
                   }));
        }
    }
}