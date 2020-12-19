using Microsoft.EntityFrameworkCore;
using OpheliaLab.ApplicationCore.Entities;
using System.Reflection;

namespace OpheliaLab.Infrastructure.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice> InvoicesLine { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
