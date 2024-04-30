using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Service.AutoMapper.Categories
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryModelView, Category>().ReverseMap();
            CreateMap<CategoryAddModelView, Category>().ReverseMap();
            CreateMap<CategoryUpdateModelView, Category>().ReverseMap();
        }
    }
}
