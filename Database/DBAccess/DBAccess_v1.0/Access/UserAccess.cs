using System.Collections.Generic;

namespace DbAccess.Access
{
    public class UserAccess
    {
        #region AddUser methods

        public void AddUser(string firstname, string lastname, string email, string password)
        {
            // make temp user
            User tempUser = new User();

            // add user to db
        }

        public void AddUser(string firstname, string middelname, string lastname, string email, string password)
        {
            // make temp user
            User tempUser = new User();

            // add user to db
        }

        #endregion
        
        public List<User> FindUser(string email)
        {
            // find user with that email in db
            List<User> listOfFoundUsers = new List<User>();

            // add found users to list

            // return list
            return listOfFoundUsers;
        }

        public void FuckAll()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [User]");
            }
        }
    }
}