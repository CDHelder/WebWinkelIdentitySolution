using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.Users
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string IBAN { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public List<StoreEmployee> EmployeeStores { get; set; }
    }
}
