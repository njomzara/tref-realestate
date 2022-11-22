using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;

namespace TrefBlock
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TrefBlockDbContext>(options =>
                            options.UseSqlServer(config.GetConnectionString("trefdb-sqlexpress"),
                            sqlServerOptions => sqlServerOptions.CommandTimeout(120))
                            );
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
        }

    }
}
