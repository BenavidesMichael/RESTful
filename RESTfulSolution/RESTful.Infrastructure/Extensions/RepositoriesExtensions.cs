using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RESTful.Core.Interfaces;
using RESTful.Core.Services;
using RESTful.Infrastructure.Interface;
using RESTful.Infrastructure.Repositories;
using RESTful.Infrastructure.Services;

namespace RESTful.Infrastructure.Extensions
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


            //singleton  = car il ne manage pas de state, valeur d'entre et valeur de sortie.
            // UrlService = prend en param baseUrl in ctor.
            services.AddSingleton<IUrlService>(provider => 
            {
                //IHttpContextAccessor = acceder au context de notre apps.
                var contextHttp = provider.GetRequiredService<IHttpContextAccessor>();
                var request = contextHttp.HttpContext.Request;
                var url = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new URLService(url);
            });
            return services;
        }
    }
}
