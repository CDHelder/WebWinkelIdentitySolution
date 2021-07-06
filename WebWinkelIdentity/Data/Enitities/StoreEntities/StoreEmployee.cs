using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.Users;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Enitities.StoreEntities
{
    public class StoreEmployee
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
