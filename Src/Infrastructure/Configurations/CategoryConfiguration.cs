using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpheliaLab.ApplicationCore.Entities;

namespace OpheliaLab.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIES");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("category_id");
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(200).IsRequired();
        }
    }
}
