using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("product_id");
            builder.Property(c => c.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(c => c.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(12, 2)").IsRequired();
            builder.Property(c => c.Quantity).HasColumnName("quantity").HasMaxLength(10).IsRequired();
            builder.Property(c => c.CategoryId).HasColumnName("category_id").IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
