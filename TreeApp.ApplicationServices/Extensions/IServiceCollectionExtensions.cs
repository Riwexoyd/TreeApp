using Microsoft.Extensions.DependencyInjection;

using TreeApp.ApplicationServices.BackgroundServices;
using TreeApp.ApplicationServices.Services;
using TreeApp.ApplicationServices.Services.Internal;

namespace TreeApp.ApplicationServices.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<TreeCreationBackgroundService>();
            serviceCollection.AddScoped<ITreeService, TreeService>();

            return serviceCollection;
        }
    }
}
