namespace WebWinkelIdentity.Core
{
    public class StoreProduct
    {
        //TODO: Verwijder Store-Product MtoMany
        // Want Een store heeft meerdere producten maar een product is uniek in elke winkel
        // Dus Winkel->Many->Product Product->One->Winkel
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
