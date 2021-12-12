using Microsoft.Extensions.DependencyInjection;

using TreeApp.Entities.Repositories;
using TreeApp.Entities.Repositories.Internal;
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

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ITreeRepository, TreeRepository>();
            return serviceCollection;
        }
    }
}
