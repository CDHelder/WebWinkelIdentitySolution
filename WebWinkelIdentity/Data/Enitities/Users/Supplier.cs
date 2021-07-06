using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.ProductEntities;

namespace WebWinkelIdentity.Data.Enitities
{
    public class Supplier : IdentityUser
    {
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
