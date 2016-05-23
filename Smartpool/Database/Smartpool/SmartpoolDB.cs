using Smartpool;

namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IPoolAccess PoolAccess { get; }
        public IUserAccess UserAccess { get; }
        public IDataAccess DataAccess { get; }

        public SmartpoolDB(IDataAccess dataAccess)
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
