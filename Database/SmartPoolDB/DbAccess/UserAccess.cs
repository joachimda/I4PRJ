using System.Collections.Generic;

namespace DbAccess
{
    public class UserAccess
    {
        #region AddUser methods

        public void AddUser(string firstname, string lastname, string email, string password)
        {
            User tempUser = new User {Email = email, Firstname = firstname, Lastname = lastname, Password = password};

            using (var db = new SmartPoolContext())
            {
                db.UserSet.Add(tempUser);
                db.SaveChanges();
            }
        }

        public void AddUser(string firstname, string middelname, string lastname, string email, string password)
        {
            User tempUser = new User { Email = email, Firstname = firstname, Lastname = lastname, Password = password, Middlename = middelname};

            using (var db = new SmartPoolContext())
            {
                db.UserSet.Add(tempUser);
                db.SaveChanges();
            }
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

        public void DeleteAllData()
        {
           
        }
    }
}