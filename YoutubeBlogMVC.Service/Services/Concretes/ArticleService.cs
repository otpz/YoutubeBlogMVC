using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Entity.ModelViews.Categories;
using YoutubeBlogMVC.Service.Extensions;
using YoutubeBlogMVC.Service.Helpers.Images;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Entity.Enums;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    internal class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _imageHelper = imageHelper;
        }

        public async Task<ArticleListModelView> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListModelView
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
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
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateModelView.Id, x => x.Category, i=>i.Image);

            if (articleUpdateModelView.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateModelView.Title, articleUpdateModelView.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateModelView.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
            }

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

            var imageUpload = await _imageHelper.Upload(articleAddModelView.Title, articleAddModelView.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddModelView.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddModelView.Title, articleAddModelView.Content, userId, userEmail, articleAddModelView.CategoryId, image.Id);

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
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleId, x => x.Category, i=>i.Image);
            var map = _mapper.Map<ArticleModelView>(article);
            return map;
        }

        public async Task<int> SaveDbAsync()
        {
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleModelView>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleModelView>>(articles);

            return map;
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<ArticleListModelView> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted &&
                (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)), 
                a => a.Category, 
                i => i.Image, 
                u => u.User
                );
                
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListModelView
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }
    }
}
