using Smartpool.UserAccess;

namespace Smartpool.Factories
{
    public class DefaultAccessFactory : DbAccessFactory
    {
        public override IUserAccess CreateUserAccess()
        {
            return new UserAccess.UserAccess();
        }
    }
}