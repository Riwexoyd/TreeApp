using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TreeApp.Entities.Models;

namespace TreeApp.Entities.Configurations
{
    internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);
            ConfigureInternal(builder);
        }

        public abstract void ConfigureInternal(EntityTypeBuilder<T> builder);
    }
}
