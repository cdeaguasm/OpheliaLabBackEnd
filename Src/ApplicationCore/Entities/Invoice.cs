using System;
using System.Collections.Generic;

namespace OpheliaLab.ApplicationCore.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Tax { get; set; }
        public decimal AmountTotal { get; set; }
        public string Notes { get; set; }
        public ICollection<InvoiceLine> InvoicesLine { get; set; }
    }
}
