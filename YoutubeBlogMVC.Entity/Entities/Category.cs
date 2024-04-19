using YoutubeBlogMVC.Core.Entities;

namespace YoutubeBlogMVC.Entity.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
