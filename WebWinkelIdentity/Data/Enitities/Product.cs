namespace WebWinkelIdentity.Data.Enitities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int AmountInStock { get; set; }
        public string SupplierId { get; set; }
    }
}