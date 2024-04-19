using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {

            // Aşağıda HasData ile tabloya ilişkileri baz alarak standart veriler ekledik. 
            builder.HasData(
            new Image
            {
                Id = Guid.Parse("FE3D8ACE-339D-40BD-B620-63FC51CE5F59"),
                FileName = "images/test_images",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Image
            {
                Id = Guid.Parse("12E5602D-BD51-4C8F-B0B0-D78024053735"),
                FileName = "images/vs_images",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
