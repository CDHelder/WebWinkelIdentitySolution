using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.StoreEntities
{
    //Change StoreProductDetails to ProductDetails
    public class ProductDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string InternationalSizingType { get; set; }
        public string Size { get; set; }
        public int AmountInStock { get; set; }
    }
}
