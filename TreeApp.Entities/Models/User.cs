using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;

namespace TreeApp.Entities.Models
{
    public sealed class User : IdentityUser<Guid>, IEntity
    {
        public DateTime RegistrationDate { get; set; }

        public ICollection<Tree> Trees { get; set; }
    }
}
