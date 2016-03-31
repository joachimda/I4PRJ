using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DbAccess
{
    public class UserAccess
    {
        #region AddUser methods

        public void AddUser(string firstname, string lastname, string email, string password)
        {
            using (var db = new SmartPoolContext())
            {
                if (FindUser(email).Count == 0)
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
                if (FindUser(email).Count == 0)
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

        //        db.PoolSet.RemoveRange(FindUser(email)[0].Pool);
        //        if (FindUser(email).Count != 0)
        //        {
        //            foreach (var pool in FindUser(email)[0].Pool)
        //            {
        //                db.PoolSet.Remove(pool);
        //            }
        //            db.PoolSet.RemoveRange(FindUser(email)[0].Pool);
        //            db.UserSet.Remove(FindUser(email)[0]);

        //            db.SaveChanges();
        //        }
        //    }
        //}

        public List<User> FindUser(string email)
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
            
            return searchResults;
        }

        public void DeleteAllUserData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [UserSet]");
            }

        }
    }
}