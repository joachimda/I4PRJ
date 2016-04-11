using Smartpool.Factories;
using Smartpool.UserAccess;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IUserAccess UserAccess { get; }
        IPoolAccess PoolAccess { get; }
    }
}