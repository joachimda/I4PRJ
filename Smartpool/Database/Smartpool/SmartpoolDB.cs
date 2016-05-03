namespace Smartpool
{
    public class SmartpoolDB : ISmartpoolDB
    {
        public IPoolAccess PoolAccess { get; }

        public SmartpoolDB(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
        }

        public void ClearEntireDatabase()
        {
            PoolAccess.DeleteAllPools();
            PoolAccess.UserAccess.DeleteAllUsers();
        }
    }
}
