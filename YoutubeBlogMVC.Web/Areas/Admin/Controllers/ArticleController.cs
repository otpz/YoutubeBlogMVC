using Microsoft.AspNetCore.Mvc;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
    }
}
