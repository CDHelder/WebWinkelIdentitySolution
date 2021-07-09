using System.Collections.Generic;
using WebWinkelIdentity.Core;

namespace WebWinkelIdentity.Data.Service.Interfaces
{
    public interface IStoreRepository
    {
        public Store GetStoreInfo(int id);
        public List<Store> GetAllStoresInfo();
        public WeekOpeningTimes GetOpeningTimes(int id);
        public List<WeekOpeningTimes> GetAllOpeningTimes();
    }
}
