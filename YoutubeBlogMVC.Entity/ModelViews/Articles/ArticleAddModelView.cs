using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.ModelViews.Categories;

namespace YoutubeBlogMVC.Entity.ModelViews.Articles
{
    public class ArticleAddModelView
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryModelView> Categories { get; set; }
    }
}
