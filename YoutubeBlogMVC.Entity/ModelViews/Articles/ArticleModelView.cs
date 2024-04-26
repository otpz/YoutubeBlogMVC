using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Entity.ModelViews.Articles
{
    public class ArticleModelView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public CategoryModelView Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
