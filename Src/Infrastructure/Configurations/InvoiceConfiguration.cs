using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("INVOICES");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("invoice_id");
            builder.Property(c => c.Number).HasColumnName("number").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Date).HasColumnName("date").IsRequired();
            builder.Property(c => c.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.Property(c => c.Tax).HasColumnName("tax").HasColumnType("decimal(4, 2)").IsRequired();
            builder.Property(c => c.AmountTotal).HasColumnName("amount_total").HasColumnType("decimal(12, 2)").IsRequired();
            builder.Property(c => c.Notes).HasColumnName("notes").HasMaxLength(500);
            builder.HasOne(x => x.Customer).WithMany(x => x.Invoices).HasForeignKey(x => x.CustomerId);
        }
    }
}
