using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Entity.ModelViews.Articles
{
    public class ArticleUpdateModelView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryModelView> Categories { get; set; }
    }
}
