using CleanArq.Application.DataBase;
using CleanArq.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<DataBaseService>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQLCnnStr"))
            );

            //DependicyInjections
            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
