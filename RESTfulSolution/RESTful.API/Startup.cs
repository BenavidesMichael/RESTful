using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RESTful.Infrastructure.Extensions;
using RESTful.Infrastructure.Filters;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace RESTful.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBase(_configuration);
            services.AddAutoMapper();

            services.AddRepositories();

            services.GetAppSettingsValues(_configuration);

            services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

            services.AddControllers(opt => opt.Filters.Add<GlobalExceptionFilter>())
                    .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()))
                    .AddJsonOptions(opt =>
                    {
                        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.ApplySwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
