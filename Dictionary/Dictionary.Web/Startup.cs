using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Data.Implementation;
using Dictionary.Web.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Dictionary.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(environment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            string connection = Configuration.GetConnectionString("DictionaryDBConnectionString");
            services.AddDbContext<DictionaryDbContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DictionaryDBConnectionString"));
                builder.EnableSensitiveDataLogging(true);
            });
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {Title = "Swagger-Web API"});
            });
            services.AddServices(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger - Web API");
            });
            app.UseSwagger();
            app.UseMvc();
        }
    }
}
