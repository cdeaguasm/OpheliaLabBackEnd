using System.Collections.Generic;

namespace OpheliaLab.ApplicationCore.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
