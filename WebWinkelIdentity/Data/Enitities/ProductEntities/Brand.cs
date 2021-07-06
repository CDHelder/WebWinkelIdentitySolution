using System.Collections.Generic;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.ProductEntities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Product> Products { get; set; }
    }
}