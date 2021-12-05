using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

using TreeApp.Entities.Models;

namespace TreeApp.Entities.Configurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        private static readonly Guid AdminUid = Guid.Parse("{1E146B68-65A5-4621-9B19-1C7FD56D2851}");

        public override void ConfigureInternal(EntityTypeBuilder<User> builder)
        {
            builder.Property(i => i.RegistrationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("now() at time zone 'utc'");

            var admin = CreateUser(AdminUid, "admin", "admin");
            builder.HasData(admin);
        }

        private static User CreateUser(Guid id, string name, string password)
        {
            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = id,
                UserName = name,
                NormalizedUserName = name.ToUpper(),
                SecurityStamp = new Guid().ToString("D")
            };

            var passwordHash = hasher.HashPassword(user, password);

            user.PasswordHash = passwordHash;

            return user;
        }
    }
}
