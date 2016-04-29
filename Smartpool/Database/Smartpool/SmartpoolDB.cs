namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IUserAccess UserAccess { get; }
        public IPoolAccess PoolAccess { get; }

        public SmartpoolDB(IUserAccess userAccess, IPoolAccess poolAccess)
        {
            UserAccess = userAccess;
            PoolAccess = poolAccess;
        }

        public void ClearEntireDatabase()
        {
            PoolAccess.DeleteAllPools();
            UserAccess.DeleteAllUsers();
        }
    }
}
