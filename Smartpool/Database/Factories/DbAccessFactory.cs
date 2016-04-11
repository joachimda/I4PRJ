using Smartpool;

namespace Smartpool
{
    public abstract class DbAccessFactory
    {
        public abstract IUserAccess CreateUserAccess();
        public abstract IPoolAccess CreatePoolAccess();
    }
}