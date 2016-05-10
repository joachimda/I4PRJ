using Smartpool.DataAccess;

namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IPoolAccess PoolAccess { get; }
        public IUserAccess UserAccess { get; }
        public IReadDataAccess ReadDataAccess { get; }

        public SmartpoolDB(IPoolAccess poolAccess, IReadDataAccess readDataAccess)
        {
            PoolAccess = poolAccess;
            ReadDataAccess = readDataAccess;
            UserAccess = PoolAccess.UserAccess;
        }

        public void ClearEntireDatabase()
        {
            ReadDataAccess.DeleteAllData();
            PoolAccess.DeleteAllPools();
            UserAccess.DeleteAllUsers();
        }
    }
}
