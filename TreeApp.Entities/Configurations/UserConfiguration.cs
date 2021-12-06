using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

using TreeApp.Entities.Models;

namespace TreeApp.Entities.Configurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        public override void ConfigureInternal(EntityTypeBuilder<User> builder)
        {
            builder.Property(i => i.RegistrationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("now() at time zone 'utc'");
        }
    }
}
