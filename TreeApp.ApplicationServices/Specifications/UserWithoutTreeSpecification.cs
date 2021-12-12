using Ardalis.Specification;

using System.Linq;

using TreeApp.Entities.Models;

namespace TreeApp.ApplicationServices.Specifications
{
    internal sealed class UserWithoutTreeSpecification : Specification<User>
    {
        public UserWithoutTreeSpecification()
        {
            Query.Where(i => !i.Trees.Any())
                .Take(15);
        }
    }
}
