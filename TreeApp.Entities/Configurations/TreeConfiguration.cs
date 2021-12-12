using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TreeApp.Entities.Models;

namespace TreeApp.Entities.Configurations
{
    internal sealed class TreeConfiguration : EntityConfiguration<Tree>
    {
        public override void ConfigureInternal(EntityTypeBuilder<Tree> builder)
        {
            builder.Property(i => i.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("now() at time zone 'utc'");

            builder.Property(i => i.Title)
                .HasMaxLength(256);
        }
    }
}
