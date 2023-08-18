using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkTest.Data
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDataAccessDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISpecificationEvaluator), typeof(SpecificationEvaluator));
            return services;
        }
    }
}
