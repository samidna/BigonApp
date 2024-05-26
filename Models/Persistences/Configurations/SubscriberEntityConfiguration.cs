using BigonApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistences.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(s => s.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(s => s.IsApproved).HasColumnType("bit");
            builder.Property(s => s.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(s => s.ApprovedAt).HasColumnType("datetime");

            builder.HasKey(s => s.Email);
        }
    }
}
