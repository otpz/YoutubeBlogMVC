using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.Context;
using YoutubeBlogMVC.Data.Repositories.Abstractions;
using YoutubeBlogMVC.Data.Repositories.Concretes;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Service.Services.Concretes;

namespace YoutubeBlogMVC.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            return services;
        }
    }
}
