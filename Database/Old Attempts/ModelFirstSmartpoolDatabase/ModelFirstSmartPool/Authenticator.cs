﻿//========================================================================
// FILENAME :   Authenticator.cs
// DESCR.   :   Class for authenticating users and providing them a
//              UserSession to pass on to future service requests
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Linq;

namespace ModelFirstSmartPool
{
    namespace Authentication
    {
        internal class Authenticator
        {
            // authenticates and provides a user with a corresponding session
            public UserSession Authenticate(string email, string password)
            {
                // returns null if user could not be authenticated based on the input   
                using (var db = new SmartPoolContext())
                {
                    // queries the database for users with the specified input
                    var userQuery = from users in db.Users
                        where users.Email == email && users.Password == password
                        select users.UserId;

                    // checks to see whether the input was matched by the query
                    var userId = new UserIdentity(userQuery.First(), password);
                    return userQuery.Any() ? new UserSession(userId, true) : null;
                }
            }

            // deauthenticates the user given by the input session
            public void Deauthenticate(ref UserSession session)
            {
                // gets the sessions authenticated id (possibly null)
                var authenticatedId = session?.Identity().AuthenticatedId;
                if (authenticatedId == null) return;

                // deauthenticates the current user
                var userId = new UserIdentity(authenticatedId.GetValueOrDefault(), "");
                session = new UserSession(userId, false);
            }

            // nullifies the input session
            public void Nullify(ref UserSession session)
            {
                session = null;
            }

            // confirms read access to data related to the user id contained in the session
            public bool ConfirmReadAccess(UserSession session)
            {
                return session.Authenticated();
            }

            // confirms write access to data related to the user id contained in the session
            public bool ConfirmWriteAccess(UserSession session)
            {
                if (session == null || session.Authenticated() == false) return false;

                // returns false if user could not be authenticated based on the input   
                using (var db = new SmartPoolContext())
                {
                    // queries the database for users matching input session
                    var userQuery = from users in db.Users
                        where
                            users.UserId == session.Identity().AuthenticatedId &&
                            users.Password == session.Identity().Password
                        select users.UserId;

                    // returns true if the input was matched by the query
                    return userQuery.Any();
                }
            }
        }
    }
}
