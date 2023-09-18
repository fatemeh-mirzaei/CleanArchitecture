using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sample.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}
