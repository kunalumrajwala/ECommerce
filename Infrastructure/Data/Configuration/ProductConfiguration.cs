using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
           builder.Property(x => x.Id).IsRequired();
           builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
           builder.Property(x => x.Description).IsRequired().HasMaxLength(180);
           builder.Property(x => x.price).HasColumnType("decimal(18,2)");
           builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(t => t.ProductTypeId);
        }
    }
}