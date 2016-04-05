using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Smartpool
{
    public class Database
    {
        IUserAccess _userAccess;

        public Database(DbAccessFactory dbAccessFactory)
        {
            _userAccess = dbAccessFactory.CreateUserAccess();
        }
    }
}
