using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Service.Services.Abstraction
{
    public interface IArticleService    
    {
        Task<List<Article>> GetAllArticlesAsync();
        Task AddArticleAsync();
        Task<int> SaveDbAsync();
    }
}
