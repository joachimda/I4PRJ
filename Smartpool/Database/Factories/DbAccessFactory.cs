using Smartpool.UserAccess;

namespace Smartpool.Factories
{
    public abstract class DbAccessFactory
    {
        public abstract IUserAccess CreateUserAccess();
    }
}