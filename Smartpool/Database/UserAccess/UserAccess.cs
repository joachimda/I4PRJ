﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartpool
{
    public class UserAccess : IUserAccess
    {
        public bool AddUser(string fullname, string email, string password)
        {
            string[] names = fullname.Split(' ');

            User user = new User() { Firstname = names[0], Lastname = names[names.Length], Email = email, Password = password };
            
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

        public bool IsEmailUsed(string email)
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