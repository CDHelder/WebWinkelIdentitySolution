using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.StoreEntities
{
    public class StoreProduct
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
