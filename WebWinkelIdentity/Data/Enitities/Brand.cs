using System.Collections.Generic;

namespace WebWinkelIdentity.Data.Enitities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Product> Products { get; set; }
    }
}