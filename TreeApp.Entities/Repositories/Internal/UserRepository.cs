using TreeApp.Entities.Models;

namespace TreeApp.Entities.Repositories.Internal
{
    internal sealed class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext)
        {
        }
    }
}
