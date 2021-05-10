using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RESTful.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTful.Infrastructure.Extensions
{
    public static class ConfigurationExtentions
    {
        public static string GetDefaultConnectionString(this IConfiguration Configuration, string name)
        {
            return Configuration.GetConnectionString(name);
        }


        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<RestFulContext>(options
                    => options.UseSqlServer(Configuration.GetDefaultConnectionString("Restful")));
            return services;
        }
    }
}
