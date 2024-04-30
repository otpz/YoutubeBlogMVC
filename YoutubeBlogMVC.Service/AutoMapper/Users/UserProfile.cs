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
            //CreateMap<UserModelView, AppUser>().ReverseMap();
            CreateMap<AppUser, UserModelView>().ReverseMap();
        }
    }
}
