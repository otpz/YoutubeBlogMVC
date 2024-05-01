using YoutubeBlogMVC.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeBlogMVC.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace YoutubeBlogMVC.Data.Context
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // model oluşturulmadan önce yapılacak config'ler
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ArticleMap()); // Article Map için yapılan config'leri uygula.

            //modelBuilder.Entity<Article>().Property(x => x.Title).HasMaxLength(150); // Burada da bir entity için config uygulanabilir. (tavsiye edilmez)

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Tüm mappingler için yapılan config'leri uygula
        }

    }
}
