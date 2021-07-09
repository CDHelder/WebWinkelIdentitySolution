﻿using System.Collections.Generic;

namespace WebWinkelIdentity.Core
{
    public class Store
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<StoreEmployee> StoreEmployees { get; set; }
        public List<StoreProduct> StoreProducts { get; set; }
        public int WeekOpeningTimesId { get; set; }
        public WeekOpeningTimes WeekOpeningTimes { get; set; }
    }
}
