using Microsoft.Extensions.Configuration;

namespace TreeApp.Entities.Services.Implimentations
{
    internal sealed class HerokuConnectionStringResolver : IConnectionStringResolver
    {
        private readonly IConfiguration _configuration;

        public HerokuConnectionStringResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CanResolve()
        {
            var value = _configuration.GetValue<string>("DATABASE_URL");
            return !string.IsNullOrEmpty(value);
        }

        public string ResolveConnectionString()
        {
            var value = _configuration.GetValue<string>("DATABASE_URL");
            return GetConnectionString(value);
        }

        private string GetConnectionString(string connectionUrl)
        {
            // Parse connection URL to connection string for Npgsql
            connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
            var pgUserPass = connectionUrl.Split("@")[0];
            var pgHostPortDb = connectionUrl.Split("@")[1];
            var pgHostPort = pgHostPortDb.Split("/")[0];
            var pgDb = pgHostPortDb.Split("/")[1];
            var pgUser = pgUserPass.Split(":")[0];
            var pgPass = pgUserPass.Split(":")[1];
            var pgHost = pgHostPort.Split(":")[0];
            var pgPort = pgHostPort.Split(":")[1];

            return $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Prefer;Trust Server Certificate=true";
        }
    }
}
