using AutoMapper;
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

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
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
            await _articleService.CreateArticleAsync(articleAddModelView);
            return RedirectToAction("Index", "Article", new {Area = "Admin"});
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
            await _articleService.UpdateArticleAsync(articleUpdateModelView);

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateModelView.Categories = categories;

            return RedirectToAction("Index", "Article", new { Area  = "Admin"});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId) 
        {

            await _articleService.SafeDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

    }
}
