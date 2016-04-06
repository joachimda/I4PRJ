using Smartpool.UserAccess;

namespace Smartpool.Factories
{
    public class StdAccessFactory : DbAccessFactory
    {
        public override IUserAccess CreateUserAccess()
        {
            return new UserAccess.UserAccess();
        }
    }
}