using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperStore.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber).IsRequired();
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.Customer).IsRequired().HasMaxLength(100);
            builder.Property(s => s.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Branch).IsRequired().HasMaxLength(50);
            builder.Property(s => s.IsCancelled).IsRequired();

            builder.HasMany(s => s.Items)
                   .WithOne(si => si.Sale)
                   .HasForeignKey(si => si.SaleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
