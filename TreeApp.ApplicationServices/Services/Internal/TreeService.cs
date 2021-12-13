using System;
using System.IO;
using System.Threading.Tasks;

using TreeApp.Core;
using TreeApp.Core.Models;
using TreeApp.Core.Services;
using TreeApp.Entities.Repositories;

namespace TreeApp.ApplicationServices.Services.Internal
{
    internal sealed class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        public async Task<double> GetTreeHeight(Guid id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);
            var seed = tree.Id.GetHashCode();

            var today = DateTime.UtcNow;

            var totalDays = today - tree.CreationDate;

            var height = TreeCalculator.CalculateHeight(totalDays.Days, seed);

            return height;
        }

        public async Task<byte[]> GetTreeImageContent(Guid id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);

            var seed = tree.Id.GetHashCode();

            var today = DateTime.UtcNow;

            var totalDays = today - tree.CreationDate;

            var height = TreeCalculator.CalculateHeight(totalDays.Days, seed);

            var treeModel = new TreeModel
            {
                Height = height,
                Seed = seed,
            };

            using var image = TreeDrawerService.DrawTree(treeModel, 2000, 2000);
            using var ms = new MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
