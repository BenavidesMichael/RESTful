using Microsoft.Extensions.DependencyInjection;
using RESTful.Core.Interfaces;
using RESTful.Infrastructure.Repositories;

namespace RESTful.Infrastructure.Extensions
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            return services;
        }
    }
}
