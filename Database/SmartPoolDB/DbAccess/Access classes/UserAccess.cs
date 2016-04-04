using System.Collections.Generic;
using System.Linq;
using DbAccess.Database_model;

namespace DbAccess
{
    public class UserAccess : IUserAccess
    {
        #region AddUser methods

        public void AddUser(string firstname, string lastname, string email, string password)
        {
            using (var db = new SmartPoolContext())
            {
                if (FindUserByEmail(email) != null)
                {
                    User tempUser = new User { Email = email, Firstname = firstname, Lastname = lastname, Password = password };
                    db.UserSet.Add(tempUser);
                    db.SaveChanges();
                }
            }
        }

        public void AddUser(string firstname, string middelname, string lastname, string email, string password)
        {
            using (var db = new SmartPoolContext())
            {
                if (FindUserByEmail(email) != null)
                {
                    User tempUser = new User { Email = email, Firstname = firstname, Lastname = lastname, Password = password, Middlename = middelname };
                    db.UserSet.Add(tempUser);
                    db.SaveChanges();
                }
            }
        }

        #endregion

        //public void RemoveUser(string email)
        //{
        //    using (var db = new SmartPoolContext())
        //    {

        //        db.PoolSet.RemoveRange(FindUserByEmail(email)[0].Pool);
        //        if (FindUserByEmail(email).Count != 0)
        //        {
        //            foreach (var pool in FindUserByEmail(email)[0].Pool)
        //            {
        //                db.PoolSet.Remove(pool);
        //            }
        //            //db.PoolSet.RemoveRange(FindUserByEmail(email)[0].Pool);
        //            //db.UserSet.Remove(FindUserByEmail(email)[0]);

        //            db.SaveChanges();
        //        }
        //    }
        //}

        public User FindUserByEmail(string email)
        {
            List<User> searchResults = new List<User>();

            using (var db = new SmartPoolContext())
            {
                var searchByEmail = from search in db.UserSet
                                    where search.Email.Equals(email)
                                    select search;

                foreach (var user in searchByEmail)
                {
                    searchResults.Add(user);
                }
            }
            return searchResults[0];
        }

        public void DeleteAllUserData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [UserSet]");
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}