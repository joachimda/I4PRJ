using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartpool
{
    public class UserAccess : IUserAccess
    {
        public bool AddUser(string fullname, string email, string password)
        {
            #region Checking 'email' and creating instance of 'User'

            // check if 'email' is already in db
            if (EmailUsed(email))
            {
                return false;
            }

            // divide 'fullname' string into stringarray, split will occour on space
            string[] names = fullname.Split(' ');

            if (names.Length <= 2)
            {
                User user = new User() { Firstname = names[0], Lastname = names[2], Email = email, Password = password };
            }
            else
            {
                User user = new User() { Firstname = names[0], Middelname = names[1], Lastname = names[2], Email = email, Password = password };
            }

            #endregion


            using (var db = new DatabaseContext())
            {

            }

            return false;
        }

        public User FindUserByEmail(string email)
        {
            List<User> listOfFoundUsers = new List<User>();

            using (var db = new DatabaseContext())
            {
                var searchByEmail = from search in db.UserSet
                                    where search.Email.Equals(email)
                                    select search;

                foreach (User user in searchByEmail)
                {
                    listOfFoundUsers.Add(user);
                }
            }

            return listOfFoundUsers[0];
        }

        public bool EmailUsed(string email)
        {
            List<User> listOfFoundUsers = new List<User>();

            using (var db = new DatabaseContext())
            {
                var searchByEmail = from search in db.UserSet
                                    where search.Email.Equals(email)
                                    select search;

                foreach (User user in searchByEmail)
                {
                    listOfFoundUsers.Add(user);
                }
            }

            if (listOfFoundUsers.Count == 0)
            {
                return false;
            }

            return true;
        }

        public bool RemoveUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}