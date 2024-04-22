using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Service.Services.Concretes;

namespace YoutubeBlogMVC.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();

            //Burada automapper'ın eklenmesi durumunda Profile'dan miras alan tüm class'ları dependency'e ekliyor. (dependency injection)
            services.AddAutoMapper(assembly); // AutoMapper'ın eklendiği katmanın ismi assembly'dir.
            

            return services;
        }
    }
}
