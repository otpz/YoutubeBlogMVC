using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface ICategoryService
    {
        public Task<List<CategoryModelView>> GetAllCategoriesNonDeleted();
    }
}
