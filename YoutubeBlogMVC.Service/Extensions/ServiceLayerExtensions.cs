using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using YoutubeBlogMVC.Service.FluentValidations;
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
            services.AddScoped<ICategoryService, CategoryService>();
            //Burada automapper'ın eklenmesi durumunda Profile'dan miras alan tüm class'ları dependency'e ekliyor. (dependency injection)
            services.AddAutoMapper(assembly); // AutoMapper'ın eklendiği katmanın ismi assembly'dir.

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
    }
}
