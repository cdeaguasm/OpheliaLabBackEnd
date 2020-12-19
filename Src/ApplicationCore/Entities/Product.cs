using System.Collections.Generic;

namespace OpheliaLab.ApplicationCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<PriceList> PriceList { get; set; }
        public ICollection<InvoiceLine> InvoicesLine { get; set; }
    }
}
