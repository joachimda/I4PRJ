﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace Smartpool
{
    public class UserAccess : IUserAccess
    {
        /// <summary>
        /// Adds a 'User'-entry to database.
        /// </summary>
        /// <param name="fullname">String containing 2 or 3 names for user.</param>
        /// <param name="email">Email for user, only one user may exist per email.</param>
        /// <param name="password">Password for user.</param>
        /// <returns>Returns true is the user could be added to the database, false if the email is used.</returns>
        public bool AddUser(string fullname, string email, string password)
        {
            #region Checking 'email' and creating instance of 'User'

            if (IsEmailInUse(email))
            {
                return false;
            }

            User user;

            if (!ValidateName(fullname))
            {
                return false;
            }

            string[] names = fullname.Split(' ');

            if (names.Length <= 2)
            {
                user = new User() { Firstname = names[0], Lastname = names[1], Email = email, Password = password };
            }
            else
            {
                user = new User() { Firstname = names[0], Middelname = names[1], Lastname = names[2], Email = email, Password = password };
            }

            #endregion

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(user);
                db.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Validates name to be used for user.
        /// </summary>
        /// <param name="fullname">Name to be validated.</param>
        /// <returns>True if name if ok, false otherwise.</returns>
        public bool ValidateName(string fullname)
        {
            string[] names = fullname.Split(' ');

            if (names.Length <= 1)
                return false;

            return true;
        }

        /// <summary>
        /// Searches database for a user with email matching argument.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Returns reference to type of User class. 
        /// If the user could not be found, the return will be null.</returns>
        public User     FindUserByEmail(string email)
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

            if (listOfFoundUsers.Count > 1)
            {
                throw new MultipleOccourencesOfEmailWasFoundException();
            }
            if (listOfFoundUsers.Count == 0)
            {
                throw new UserNotFoundException();
                //return null;
            }

            return listOfFoundUsers[0];
        }

        /// <summary>
        /// Method to check for existing email.
        /// </summary>
        /// <param name="email">Checks for this email.</param>
        /// <returns>Return true if the email is already used. 
        /// False if no entry was found with that email.</returns>
        public bool IsEmailInUse(string email)
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

        /// <summary>
        /// Method will checkout if email and password is a match.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if the password matches the email. 
        /// False otherwise.</returns>
        public bool ValidatePassword(string email, string password)
        {
            User user = FindUserByEmail(email);

            if (user == null)
            {
                return false;
            }
            if (user.Password == password)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method will search for a User with argument email and remove
        /// user from database.
        /// </summary>
        /// <param name="email">Email of user to be deleted from database.</param>
        public void RemoveUser(string email)
        {
            using (var db = new DatabaseContext())
            {
                if (!IsEmailInUse(email))
                {
                    throw new UserNotFoundException();
                }

                var removeUserByEmail = from user in db.UserSet
                                        where user.Email == email
                                        select user;

                foreach (var user in removeUserByEmail)
                {
                    db.UserSet.Remove(user);
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes all users in database. Use while debugging and testing.
        /// </summary>
        public void DeleteAllUsers()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [UserSet]");
            }
        }
        /// <summary>
        /// Edits a single user's password
        /// </summary>
        /// <param name="email">The email of the </param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool EditUserPassword(string email, string newPassword)
        {
            if (!IsEmailInUse(email) || newPassword.Length == 0)
            {
                return false;
            }

            using (var db = new DatabaseContext())
            {
                var original = db.UserSet.Find(FindUserByEmail(email).Id);
                if (original != null)
                {
                    original.Password = newPassword;
                    db.SaveChanges();
                }
            }

            return true;
        }

        public bool EditUserEmail(string email, string newEmail)
        {
            if (!IsEmailInUse(email) || newEmail.Length == 0)
            {
                return false;
            }

            using (var db = new DatabaseContext())
            {
                var original = db.UserSet.Find(FindUserByEmail(email).Id);
                if (original != null)
                {
                    original.Email = newEmail;
                    db.SaveChanges();
                }
            }
            return true;
        }

        public bool EditUserName(string email, string newName)
        {
            if (!IsEmailInUse(email))
            {
                return false;
            }

            string[] names = newName.Split(' ');
            if (names.Length < 2)
            {
                return false;
            }

            using (var db = new DatabaseContext())
            {
                var original = db.UserSet.Find(FindUserByEmail(email).Id);

                if (original != null)
                {
                    if (names.Length == 2)
                    {
                        original.Firstname = names[0];
                        original.Middelname = null;
                        original.Lastname = names[1];
                    }

                    if (names.Length == 3)
                    {
                        original.Firstname = names[0];
                        original.Middelname = names[1];
                        original.Lastname = names[2];
                    }
                    db.SaveChanges();
                }
            }
            return true;
        }
    }
}