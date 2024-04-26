﻿using System;
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

        Task CreateArticleAsync(ArticleAddModelView articleAddModelView);

        Task<int> SaveDbAsync();
    }
}
