using Smartpool.UserAccess;

namespace Smartpool.Factories
{
    public abstract class DbAccessFactory
    {
        public abstract IUserAccess CreateUserAccess();
        public abstract IPoolAccess CreatePoolAccess();

    }
}