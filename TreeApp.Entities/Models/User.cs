using Microsoft.AspNetCore.Identity;

using System;

namespace TreeApp.Entities.Models
{
    public sealed class User : IdentityUser<Guid>, IEntity
    {
        public DateTime RegistrationDate { get; set; }
    }
}
