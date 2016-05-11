using Smartpool;

namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IPoolAccess PoolAccess { get; }
        public IUserAccess UserAccess { get; }
        public IReadDataAccess DataAccess { get; set; }

        public SmartpoolDB(IReadDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            PoolAccess = dataAccess.PoolAccess;
            UserAccess = dataAccess.PoolAccess.UserAccess;
        }

        public void ClearEntireDatabase()
        {
            PoolAccess.DeleteAllPools();
            UserAccess.DeleteAllUsers();
        }
    }
}
