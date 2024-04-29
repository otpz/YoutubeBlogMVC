using YoutubeBlogMVC.Core.Entities;

namespace YoutubeBlogMVC.Entity.Entities
{
    public class Article : EntityBase
    {

        // Aşağıdaki 3 farklı ctor un amacı şudur;
        // Kullanıcı isterse boş bir instance, isterse 5 alan olan bir instance üretebilir.
        // Instance üretirken de bu alanların zorunlu olup olmadığını görebilir.
        public Article()
        {
            
        }

        public Article(string title, string content, Guid userId, Guid categoryId, Guid imageId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
            //ViewCount = 0; // burada viewcount = 0 denebilir fakat ctor'un amacı bu değildir, parametrelerden okumaktır.
        }

        //public Article(string title, string content, Guid userId)
        //{
            
        //}


        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }   
    }
}
