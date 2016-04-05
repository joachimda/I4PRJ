using Smartpool.Factories;
using Smartpool.UserAccess;

namespace Smartpool
{
    public class SmartpoolDB
    {
        public IUserAccess UserAccess { get; set; }

        public SmartpoolDB(DbAccessFactory dbAccessFactory)
        {
            UserAccess = dbAccessFactory.CreateUserAccess();
        }
    }
}
