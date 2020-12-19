using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.ToTable("PRICE_LIST");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("price_list_id");
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(100).IsRequired();
            builder.Property(c => c.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(c => c.Price).HasColumnName("price").HasColumnType("decimal(12, 2)").IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.PriceList).HasForeignKey(x => x.ProductId);
        }
    }
}
