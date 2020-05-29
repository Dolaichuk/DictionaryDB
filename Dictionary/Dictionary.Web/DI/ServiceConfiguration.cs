using Dictionary.Repositories.Abstraction;
using Dictionary.Repositories.Implementation;
using Dictionary.Services.Interface;
using Dictionary.Services.Service;
using Library.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Dictionary.Web.DI
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped <IEnglishIdiomRepository, EnglishIdiomRepository>();
            services.AddScoped <IUsageRepository, UsageRepository>();
            services.AddScoped<IExplanationRepository, ExplanationRepository>();


            services.AddScoped <IEnglishIdiomService, EnglishIdiomService>();
            services.AddScoped<IUsageService, UsageService>();
            services.AddScoped<IExplanationService, ExplanationService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
    }
}
