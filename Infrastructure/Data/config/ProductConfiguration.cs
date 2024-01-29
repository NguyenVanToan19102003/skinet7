
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.description).IsRequired().HasMaxLength(180);
            builder.Property(p => p.price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.pictureUrl).IsRequired();

            builder.HasOne(t => t.producttype).WithMany()
                .HasForeignKey(p => p.producttypeId);
            builder.HasOne(b => b.productbrand).WithMany()
                .HasForeignKey(p => p.productbrandId);     
        }
    }
}