namespace OpheliaLab.ApplicationCore.Entities
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
    }
}
