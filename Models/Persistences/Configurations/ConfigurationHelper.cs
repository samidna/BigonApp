using BigonApp.Models.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistences.Configurations
{
    public static class ConfigurationHelper
    {
        public static EntityTypeBuilder<T> ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder)
            where T : AuditableEntity
        {
            builder.Property(c => c.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.Property(c => c.ModifiedBy).HasColumnType("int");
            builder.Property(c => c.ModifiedAt).HasColumnType("datetime");

            builder.Property(c => c.DeletedBy).HasColumnType("int");
            builder.Property(c => c.DeletedAt).HasColumnType("datetime");

            return builder;
        }
    }
}
