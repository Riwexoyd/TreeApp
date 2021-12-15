using Ardalis.Specification;

using System.Linq;

using TreeApp.Entities.Models;

namespace TreeApp.ApplicationServices.Specifications
{
    internal sealed class TreeByUserNameSpecification : Specification<Tree>
    {
        public TreeByUserNameSpecification(string name)
        {
            Query.Where(i => i.Owner.UserName == name);
        }
    }
}
