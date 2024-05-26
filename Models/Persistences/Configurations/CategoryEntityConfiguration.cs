using BigonApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistences.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).HasColumnType("int");
            builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ConfigureAsAuditable();

            builder.HasKey(c => c.Id);
        }
    }
}
