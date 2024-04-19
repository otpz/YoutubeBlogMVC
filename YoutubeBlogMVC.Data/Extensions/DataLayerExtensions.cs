using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeBlogMVC.Data.Context;
using YoutubeBlogMVC.Data.Repositories.Abstractions;
using YoutubeBlogMVC.Data.Repositories.Concretes;
using YoutubeBlogMVC.Data.UnitOfWorks;

namespace YoutubeBlogMVC.Data.Extensions
{
    // Bu class ve metot program.cs'de servisler kısmında çağrılır. Program başlarken hangi servisleri kullanacağını ayarlar
    // bu servisi program.cs yerine burada tanımlamak kod okunabilirliğini arttırır.
    // IServiceCollection interface'i bir servis tanımlanacağında kullanılır.
    // bu servisin data katmanı altında olmasının en büyük sebebi data ile alakalı işlemler barındırmasıdır.
    public static class DataLayerExtensions 
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
