//========================================================================
// FILENAME :   Authenticator.cs
// DESCR.   :   Class for authenticating users and providing them a
//              UserSession to pass on to future service requests
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  AK      Authenticator Interfaced
//========================================================================

using System;
using System.Linq;
using Smartpool.UserAccess;

namespace Smartpool.Application.Model
{
    public class Authenticator : IAuthenticator
    {
        // authenticates and provides a user with a corresponding session
        public UserSession Authenticate(string email, string password)
        {
            // get users from the database matching the email
            var access = new UserAccess();
            var users = access.FindUser(email);

            // return null if no users match the email
            if (users.Count == 0) return null;

            // check the password
            var user = users.First();
            var userId = new UserIdentity(user.Id, password);
            return (user.Password == password) ? new UserSession(userId, true) : null;
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
                var userQuery = from users in db.UserSet
                                where
                                    users.Id == session.Identity().AuthenticatedId &&
                                    users.Password == session.Identity().Password
                                select users.Id;

                // returns true if the input was matched by the query
                return userQuery.Any();
            }
        }
    }
}
