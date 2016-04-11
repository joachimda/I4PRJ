using Smartpool;

namespace Smartpool
{
    public class StdAccessFactory : DbAccessFactory
    {
        public override IUserAccess CreateUserAccess()
        {
            return new UserAccess();
        }

        public override IPoolAccess CreatePoolAccess()
        {
            return new PoolAccess(); 
        }
    }
}