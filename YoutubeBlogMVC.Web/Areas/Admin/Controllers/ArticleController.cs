using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddModelView {Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddModelView articleAddModelView)
        {
            var map = _mapper.Map<Article>(articleAddModelView);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddModelView { Categories = categories });
                // yukarıdaki işlemler validation içindir.
            }

            await _articleService.CreateArticleAsync(articleAddModelView);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticlesWithCategoryNonDeletedAsync(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateModelView = _mapper.Map<ArticleUpdateModelView>(article);
            articleUpdateModelView.Categories = categories;

            return View(articleUpdateModelView);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateModelView articleUpdateModelView)
        {
            var map = _mapper.Map<Article>(articleUpdateModelView);
            var result = await _validator.ValidateAsync(map);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                // yukarıdaki işlemler validation içindir.
            }

            await _articleService.UpdateArticleAsync(articleUpdateModelView);
            articleUpdateModelView.Categories = categories;
            return View(articleUpdateModelView);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId) 
        {

            await _articleService.SafeDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

    }
}
