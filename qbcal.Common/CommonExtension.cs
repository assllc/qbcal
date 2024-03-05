using Microsoft.Extensions.DependencyInjection;
using qbcal.Common.Helpers.Helper;
using qbcal.Common.Helpers.Interfaces;

namespace qbcal.Common
{
    public static class CommonExtension
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppLogger, AppLogger>();
        }
    }
}
