using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solvace.TechCase.Domain.Inerface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Services.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services = services.AddScoped<IPlan, ActionPlanService>();
            return services;
        }
    }
}
