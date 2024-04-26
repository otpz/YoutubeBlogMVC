using Microsoft.AspNetCore.Mvc;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
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

    }
}
