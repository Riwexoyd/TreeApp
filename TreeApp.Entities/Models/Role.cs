using Microsoft.AspNetCore.Identity;

using System;

namespace TreeApp.Entities.Models
{
    public sealed class Role : IdentityRole<Guid>, IEntity
    {

    }
}
