using Smartpool;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IPoolAccess PoolAccess { get; }
        IUserAccess UserAccess { get; }
        IDataAccess DataAccess { get; }
        void ClearEntireDatabase();
    }
}