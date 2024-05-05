using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Web.Models;

namespace YoutubeBlogMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var article = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);

            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var article = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(article);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
