using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Interfaces;
using Sample.Application.Services;
using Sample.Domain.Persistence.Contracts;
using Sample.Infrastructure.Persistence.Repositories;

namespace Sample.Infrastructure.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));


            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion



            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion



            return services;
        }
    }
}
