using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMERS");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("customer_id");
            builder.Property(c => c.IdentificationType).HasColumnName("ID_type").HasMaxLength(10).IsRequired();
            builder.Property(c => c.IdentificationNumber).HasColumnName("ID_number").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Surname).HasColumnName("surname").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Birthdate).HasColumnName("birthdate").IsRequired();
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).HasColumnName("phone_number").HasMaxLength(15);
        }
    }
}
