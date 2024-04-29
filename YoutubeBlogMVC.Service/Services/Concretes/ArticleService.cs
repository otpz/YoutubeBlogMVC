using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Entity.ModelViews.Categories;
using YoutubeBlogMVC.Service.Extensions;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    internal class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateModelView articleUpdateModelView)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateModelView.Id, x => x.Category);

            article.Title = articleUpdateModelView.Title;
            article.CategoryId = articleUpdateModelView.CategoryId;
            article.Content = articleUpdateModelView.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task CreateArticleAsync(ArticleAddModelView articleAddModelView)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageId = Guid.Parse("FE3D8ACE-339D-40BD-B620-63FC51CE5F59");

            var article = new Article(articleAddModelView.Title, articleAddModelView.Content, userId, userEmail, articleAddModelView.CategoryId, imageId);

            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleModelView>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == false, x=> x.Category);
            var map = _mapper.Map<List<ArticleModelView>>(articles);
            return map;
        }

        public async Task<ArticleModelView> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleId, x => x.Category);
            var map = _mapper.Map<ArticleModelView>(article);
            return map;
        }

        public async Task<int> SaveDbAsync()
        {
            return await _unitOfWork.SaveAsync();
        }
    }
}
