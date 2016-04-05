using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
