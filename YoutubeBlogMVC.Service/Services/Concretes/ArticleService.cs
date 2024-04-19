using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    internal class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _unitOfWork.GetRepository<Article>().GetAllAsync();
        }
    }
}
