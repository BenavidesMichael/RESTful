using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RESTful.Infrastructure.Extensions;
using System;

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

            services.AddSwagger();
            
            services.AddControllers()
                    .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
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
