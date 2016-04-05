using Smartpool.Factories;
using Smartpool.UserAccess;

namespace Smartpool
{
    public class SmartpoolDB
    {
        public IUserAccess UserAccess { get; }

        public SmartpoolDB(DbAccessFactory dbAccessFactory)
        {
            UserAccess = dbAccessFactory.CreateUserAccess();
        }
    }
}
