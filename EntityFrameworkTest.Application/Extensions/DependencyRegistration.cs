using EntityFrameworkTest.Data;
using EntityFrameworkTest.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkTest.Application.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterDataAccessDependencies();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
