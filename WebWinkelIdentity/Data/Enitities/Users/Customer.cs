using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWinkelIdentity.Data.Enitities
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}
