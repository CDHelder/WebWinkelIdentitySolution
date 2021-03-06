using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities;
using WebWinkelIdentity.Data.Enitities.Users;

namespace WebWinkelIdentity.Data.StoreEntities
{
    public class Store
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Employee> Employees { get; set; }
        public List<StoreProduct> StoreProducts { get; set; }
        public int WeekOpeningTimesId { get; set; }
        public WeekOpeningTimes WeekOpeningTimes { get; set; }
    }
}
