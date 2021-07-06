using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.ProductEntities;
using WebWinkelIdentity.Data.Enitities.StoreEntities;

namespace WebWinkelIdentity.Data.StoreEntities
{
    //TODO: Change StoreProduct to Product
    public class StoreProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public List<StoreProductDetails> StoreProductDetails { get; set; }
    }
}
