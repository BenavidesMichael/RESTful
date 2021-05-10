using Microsoft.Extensions.DependencyInjection;
using System;

namespace RESTful.Infrastructure.Extensions
{
    public static class AutoMapperExtentions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // cherche moi dans tout les projets les profiles a compiler.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
