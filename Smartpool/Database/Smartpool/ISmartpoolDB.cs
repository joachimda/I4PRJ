using Smartpool.DataAccess;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IPoolAccess PoolAccess { get; }
        IUserAccess UserAccess { get; }
        IReadDataAccess ReadDataAccess { get; }
        void ClearEntireDatabase();
    }
}