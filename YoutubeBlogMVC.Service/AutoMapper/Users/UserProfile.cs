using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Users;

namespace YoutubeBlogMVC.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserModelView>().ReverseMap();
            CreateMap<AppUser, UserAddModelView>().ReverseMap();
            CreateMap<AppUser, UserUpdateModelView>().ReverseMap();
            CreateMap<AppUser, UserProfileModelView>().ReverseMap();
        }
    }
}
