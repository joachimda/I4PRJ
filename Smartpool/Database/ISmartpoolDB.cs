using Smartpool.UserAccess;

namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IUserAccess UserAccess { get; }
    }
}