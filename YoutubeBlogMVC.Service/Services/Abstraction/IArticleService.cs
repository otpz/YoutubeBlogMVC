using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface IArticleService    
    {
        Task<List<ArticleModelView>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleModelView>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleModelView> GetArticlesWithCategoryNonDeletedAsync(Guid articleId);
        Task<string> UpdateArticleAsync(ArticleUpdateModelView articleUpdateModelView);
        Task CreateArticleAsync(ArticleAddModelView articleAddModelView);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<int> SaveDbAsync();
    }
}
