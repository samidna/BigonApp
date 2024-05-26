using BigonApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistences.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c => c.Id).HasColumnType("int");
            builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(25).IsRequired();
            builder.Property(c => c.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();

            builder.ConfigureAsAuditable();

            builder.HasKey(c=>c.Id);
        }
    }
}
