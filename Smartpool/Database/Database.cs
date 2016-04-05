using Smartpool.UserAccess;

namespace Smartpool
{
    public class Database
    {
        public IUserAccess UserAccess { get; set; }

        public Database(DbAccessFactory dbAccessFactory)
        {
            UserAccess = dbAccessFactory.CreateUserAccess();
        }
    }
}
