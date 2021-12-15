using System;
using System.IO;
using System.Threading.Tasks;

using TreeApp.ApplicationServices.Models;
using TreeApp.ApplicationServices.Specifications;
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

        public async Task<byte[]> GetTreeImageContent(Guid id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);

            var seed = GetSeed(id);

            var treeModel = new TreeModel
            {
                Height = GetHeight(tree.CreationDate, seed),
                Seed = seed,
            };

            using var image = TreeDrawerService.DrawTree(treeModel, 2000, 2000);
            using var ms = new MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public async Task<TreeInfoModel> GetUserMainTreeInfo(string userName)
        {
            var tree = await _treeRepository.FirstOrDefaultAsync(new TreeByUserNameSpecification(userName));
            var height = GetHeight(tree.CreationDate, GetSeed(tree.Id));
            return new TreeInfoModel
            {
                Age = new TreeAge(tree.CreationDate),
                Height = new TreeHeight(height),
                Id = tree.Id,
            };
        }

        private static double GetHeight(DateTime creationDate, int seed)
        {
            var today = DateTime.UtcNow;

            var totalDays = today - creationDate;

            var height = TreeCalculator.CalculateHeight(totalDays.Days, seed);

            return height;
        }

        private static int GetSeed(Guid id)
        {
            return Math.Abs(id.GetHashCode());
        }
    }
}
