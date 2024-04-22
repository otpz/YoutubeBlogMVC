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

        public async Task AddArticleAsync()
        {
            var article = new Article
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.Parse("bfdeca74-b674-49fd-9a3d-be63b8266645"),
                Content = "Content deneme örnek 1",
                CreatedBy = "Osman Topuz",
                CreatedDate = DateTime.Now,
                ImageId = Guid.Parse("12e5602d-bd51-4c8f-b0b0-d78024053735"),
                IsDeleted = false,
                ModifiedBy = null,
                ModifiedDate = null,
                Title = "Deneme Makale başlık",
                ViewCount = 0,
                DeletedBy = null,
                DeletedDate = null,
            };
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
        }

        public async Task<int> SaveDbAsync()
        {
            return await _unitOfWork.SaveAsync();
        }
    }
}
