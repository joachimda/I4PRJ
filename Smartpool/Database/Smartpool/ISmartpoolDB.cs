using Smartpool;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IUserAccess UserAccess { get; }
        IPoolAccess PoolAccess { get; }
        void ClearEntireDatabase();
    }
}