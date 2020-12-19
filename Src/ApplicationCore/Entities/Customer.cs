using System;
using System.Collections.Generic;

namespace OpheliaLab.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
