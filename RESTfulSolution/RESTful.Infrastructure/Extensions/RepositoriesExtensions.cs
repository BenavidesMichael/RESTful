using Microsoft.Extensions.DependencyInjection;
using RESTful.Core.Interfaces;
using RESTful.Core.Services;
using RESTful.Infrastructure.Repositories;

namespace RESTful.Infrastructure.Extensions
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
