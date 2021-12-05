using Microsoft.Extensions.DependencyInjection;

using TreeApp.Entities.Services;
using TreeApp.Entities.Services.Implimentations;

namespace TreeApp.Entities.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConnectionStringResolver, DefaultConnectionStringResolver>();
            serviceCollection.AddScoped<IConnectionStringResolver, HerokuConnectionStringResolver>();
            return serviceCollection;
        }
    }
}
