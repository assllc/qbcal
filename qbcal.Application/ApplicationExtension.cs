using Microsoft.Extensions.DependencyInjection;
using qbcal.Application.Interfaces;
using qbcal.Application.Services;

namespace qbcal.Application
{
    public static class ApplicationExtension
    {
        // di services
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMigrationService, MigrationService>();
        }
    }
}
