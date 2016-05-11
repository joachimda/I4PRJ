using Smartpool.DataAccess;

namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IPoolAccess PoolAccess { get; }
        public IUserAccess UserAccess { get; }

        public SmartpoolDB(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
            UserAccess = PoolAccess.UserAccess;
        }

        public void ClearEntireDatabase()
        {
            PoolAccess.DeleteAllPools();
            UserAccess.DeleteAllUsers();
        }
    }
}
