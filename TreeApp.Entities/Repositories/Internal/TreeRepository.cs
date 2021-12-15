using TreeApp.Entities.Models;

namespace TreeApp.Entities.Repositories.Internal
{
    internal sealed class TreeRepository : AsyncRepository<Tree>, ITreeRepository
    {
        public TreeRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext)
        {
        }
    }
}
