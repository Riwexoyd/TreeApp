using Microsoft.Extensions.Configuration;

namespace TreeApp.Entities.Services.Implimentations
{
    internal sealed class DefaultConnectionStringResolver : IConnectionStringResolver
    {
        private readonly IConfiguration _configuration;

        public DefaultConnectionStringResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CanResolve()
        {
            return !string.IsNullOrEmpty(_configuration.GetConnectionString("DefaultConnection"));
        }

        public string ResolveConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
