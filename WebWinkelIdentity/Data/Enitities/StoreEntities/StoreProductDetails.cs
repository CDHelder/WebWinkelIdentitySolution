using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Enitities.StoreEntities
{
    //Change StoreProductDetails to ProductDetails
    public class StoreProductDetails
    {
        public int Id { get; set; }
        public int StoreProductId { get; set; }
        public string InternationalSizingType { get; set; }
        public string Size { get; set; }
        public int AmountInStock { get; set; }
    }
}
