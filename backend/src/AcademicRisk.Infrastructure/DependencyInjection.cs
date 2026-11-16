using AcademicRisk.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicRisk.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("AcademicRisk")
                ?? throw new InvalidOperationException("Missing AcademicRisk connection string.");

            services.AddDbContext<AcademicRiskDbContext>(options =>
                options.UseNpgsql(cs)
                .UseSnakeCaseNamingConvention());

            return services;
        }
    }
}
