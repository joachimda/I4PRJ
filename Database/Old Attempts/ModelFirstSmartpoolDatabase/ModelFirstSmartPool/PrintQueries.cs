using System;
using System.Linq;

namespace ModelFirstSmartPool
{
    public class PrintQueries
    {
        public void GetAllUsers()
        {
            using (var db = new SmartPoolContext())
            {
                var userQuery = from users in db.Users
                    orderby users.FullName.FirstName
                    select users;

                foreach (var user in userQuery)
                {
                    //Console.WriteLine(user.FullName.FirstName + " " + user.FullName.MiddleName + " " + user.FullName.LastName);
                    Console.WriteLine(user.FullName.FirstName);
                    
                }
            }
        }
    }
}