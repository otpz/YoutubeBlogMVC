using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<List<CategoryModelView>> GetAllCategoriesNonDeleted();
        Task<List<CategoryModelView>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddModelView categoryAddModelView);
        Task<Category> GetCategoryByGuid(Guid categoryId);
        Task<string> UpdateCategoryAsync(CategoryUpdateModelView categoryUpdateModelView);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
    }
}
