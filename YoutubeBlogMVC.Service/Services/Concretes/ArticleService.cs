using AutoMapper;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    internal class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddModelView articleAddModelView)
        {
            var userId = Guid.Parse("AB5CEB8F-9DC0-424A-A1C9-495BCA357321");

            var article = new Article
            {
                Title = articleAddModelView.Title,
                Content = articleAddModelView.Content,
                CategoryId = articleAddModelView.CategoryId,
                UserId = userId,
            };

            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleModelView>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == false, x=> x.Category);
            var map = _mapper.Map<List<ArticleModelView>>(articles);
            return map;
        }

        public async Task<int> SaveDbAsync()
        {
            return await _unitOfWork.SaveAsync();
        }
    }
}
