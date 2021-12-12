using Microsoft.Extensions.DependencyInjection;

using TreeApp.ApplicationServices.BackgroundServices;

namespace TreeApp.ApplicationServices.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<TreeCreationBackgroundService>();

            return serviceCollection;
        }
    }
}
