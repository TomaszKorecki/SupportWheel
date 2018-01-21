using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SupportWheelOfFateAPI.Models.Configuration;
using SupportWheelOfFateInfrastructure.Interfaces;
using SupportWheelOfFateAPI.Services;

namespace SupportWheelOfFateAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            services.Configure<SupportWheelConfiguration>(configuration.GetSection("supportWheelConfiguration"));

            services.AddMemoryCache();
            services.AddCors();
            services.AddMvc();

            services.AddScoped<ISupportListGenerator, SupportListGenerator>();
            services.AddScoped<ISupportListRepository, SupportListRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

      


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
            );

            app.UseMvc();
        }
    }
}
