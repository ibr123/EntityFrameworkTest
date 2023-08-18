using EntityFrameworkTest.Data;
using EntityFrameworkTest.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkTest.Application.Extensions
{
    public static class RegisterDbContext
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new DbContextCustomOptions() { ConnectionString = connectionString });
            services.AddDbContext<DataContext>();

            services.AddScoped<IUnitOfWork>(u =>
            {
                var applicationDbContext = u.GetRequiredService<DataContext>();
                return new UnitOfWork(applicationDbContext);
            });

            return services;
        }        
    }
}
