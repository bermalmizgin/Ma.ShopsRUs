using Ma.ShopsRUs.Data;
using Ma.ShopsRUs.Interfaces;
using Ma.ShopsRUs.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }


        public static void ConfigureSqlLite(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqlLiteConnection")));

        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("SqlServerConnection")));
    }
}
