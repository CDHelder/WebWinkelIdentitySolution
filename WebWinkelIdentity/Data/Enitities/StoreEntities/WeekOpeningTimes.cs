using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.StoreEntities;

namespace WebWinkelIdentity.Data.StoreEntities
{
    public class WeekOpeningTimes
    {
        public int Id { get; set; }
        public List<DayOpeningTime> DayOpeningTimes { get; set; }
    }
}
