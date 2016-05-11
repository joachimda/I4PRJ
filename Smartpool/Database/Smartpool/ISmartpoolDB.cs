using Smartpool;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IPoolAccess PoolAccess { get; }
        IUserAccess UserAccess { get; }
        void ClearEntireDatabase();
    }
}