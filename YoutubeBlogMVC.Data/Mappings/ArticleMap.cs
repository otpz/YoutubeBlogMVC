using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Data.Mappings
{
    // Articles tablosu için ayarlar 
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder.HasKey(x => x.Id); // Zaten unique olduğu için gerek yok
            builder.Property(x => x.Title).HasMaxLength(150); // Burada Article.Title prop'unun database'de max uzunluğunun 150 karakter olarak set edilmesini sağlıyoruz.

            // Aşağıda HasData ile tabloya ilişkileri baz alarak standart veriler ekledik. 
            builder.HasData(
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "ASP.NET CORE Deneme Makalesi 1",
                Content = "ASP.NET CORE Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.",
                ViewCount = 15,
                CategoryId = Guid.Parse("51C55032-6F6A-47D8-833F-144C23FB67A1"),
                ImageId = Guid.Parse("FE3D8ACE-339D-40BD-B620-63FC51CE5F59"),
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("AB5CEB8F-9DC0-424A-A1C9-495BCA357321"),
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio orem ipsum dolor sit amet, consectetur adipiscing elit. Ut arcu ante, condimentum non nibh eu, vehicula tristique eros. Praesent metus felis, rhoncus nec neque at, feugiat ultrices ligula. Integer porta, leo et tempor suscipit, mi ligula viverra lectus, nec tristique massa ante ut mi. Etiam eget tempus tortor. Duis facilisis commodo interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam dui lectus, sodales in ex id, tincidunt pharetra quam.",
                ViewCount = 15,
                CategoryId = Guid.Parse("BFDECA74-B674-49FD-9A3D-BE63B8266645"),
                ImageId = Guid.Parse("12E5602D-BD51-4C8F-B0B0-D78024053735"),
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("3D75895A-13AF-4E93-8091-6CD22C173F83"),
            }
            );

        }
    }
}

