namespace WebWinkelIdentity.Core
{
    public class ProductDetails
    {
        //TODO: ProductDetail verwerken in Product
        //      Nieuwe maat = nieuw product (en nieuw productId)
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string InternationalSizingType { get; set; }
        public string Size { get; set; }
        public int AmountInStock { get; set; }
    }
}
