using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("INVOICES_LINE");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("invoice_line_id");
            builder.Property(c => c.InvoiceId).HasColumnName("invoice_id").IsRequired();
            builder.Property(c => c.ProductId).HasColumnName("product_id").IsRequired();
            builder.Property(c => c.Quantity).HasColumnName("quantity").HasMaxLength(10).IsRequired();
            builder.Property(c => c.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(12, 2)").IsRequired();
            builder.HasOne(x => x.Invoice).WithMany(x => x.InvoicesLine).HasForeignKey(x => x.InvoiceId);
            builder.HasOne(x => x.Product).WithMany(x => x.InvoicesLine).HasForeignKey(x => x.ProductId);
        }
    }
}
