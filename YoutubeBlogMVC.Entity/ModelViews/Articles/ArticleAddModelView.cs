using Microsoft.AspNetCore.Http;

using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Entity.ModelViews.Articles
{
    public class ArticleAddModelView
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile Photo {  get; set; }
        public IList<CategoryModelView> Categories { get; set; }
    }
}
