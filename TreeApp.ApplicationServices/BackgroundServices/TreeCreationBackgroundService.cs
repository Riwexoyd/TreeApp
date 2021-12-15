using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Threading;
using System.Threading.Tasks;

using TreeApp.ApplicationServices.Specifications;
using TreeApp.Entities.Models;
using TreeApp.Entities.Repositories;

namespace TreeApp.ApplicationServices.BackgroundServices
{
    internal sealed class TreeCreationBackgroundService : BackgroundService
    {
        private readonly ILogger<TreeCreationBackgroundService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TreeCreationBackgroundService(ILogger<TreeCreationBackgroundService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"TreeCreationBackgroundService is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" Tree creation background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"Tree creation task doing background work.");

                await CheckUserTrees();

                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogDebug($"Tree creation background task is stopping.");
        }

        private async Task CheckUserTrees()
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var treeRepository = scope.ServiceProvider.GetRequiredService<ITreeRepository>();

            var users = await userRepository.ListAsync(new UserWithoutTreeSpecification());
            foreach (var user in users)
            {
                var tree = new Tree
                {
                    Owner = user,
                    CreationDate = user.RegistrationDate
                };

                await treeRepository.AddAsync(tree);
            }
        }
    }
}
