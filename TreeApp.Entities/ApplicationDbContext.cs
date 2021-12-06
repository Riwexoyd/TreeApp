using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

using TreeApp.Entities.Models;
using TreeApp.Entities.Services;
using TreeApp.Utils;

namespace TreeApp.Entities
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IConnectionStringResolver _connectionStringResolver;

        public ApplicationDbContext(IEnumerable<IConnectionStringResolver> connectionStringResolvers)
        {
            _connectionStringResolver = connectionStringResolvers.FirstOrDefault(i => i.CanResolve());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Contracts.ThrowIfNull(_connectionStringResolver, nameof(_connectionStringResolver));
            var connectionString = _connectionStringResolver.ResolveConnectionString();
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
