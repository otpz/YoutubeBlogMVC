//using YoutubeBlogMVC.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            // Aşağıda HasData ile tabloya ilişkileri baz alarak standart veriler ekledik. 
            builder.HasData(new Category
            {
                Id = Guid.Parse("51C55032-6F6A-47D8-833F-144C23FB67A1"),
                Name = "ASP.NET CORE",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,

            },
            new Category
            {
                Id = Guid.Parse("BFDECA74-B674-49FD-9A3D-BE63B8266645"),
                Name = "Visual Studio 2022",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
