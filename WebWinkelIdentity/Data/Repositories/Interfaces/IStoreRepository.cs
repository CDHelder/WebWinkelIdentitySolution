using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.Enitities.StoreEntities;
using WebWinkelIdentity.Data.StoreEntities;

namespace WebWinkelIdentity.Data.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        public Store GetStoreInfo(int id);
        public List<Store> GetAllStoresInfo();
        public WeekOpeningTimes GetOpeningTimes(int id);
        public List<WeekOpeningTimes> GetAllOpeningTimes();
    }
}
