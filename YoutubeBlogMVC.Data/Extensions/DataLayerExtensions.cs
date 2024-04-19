using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.Repositories.Abstractions;
using YoutubeBlogMVC.Data.Repositories.Concretes;

namespace YoutubeBlogMVC.Data.Extensions
{
    public static class DataLayerExtensions 
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
