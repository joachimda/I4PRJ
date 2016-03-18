//========================================================================
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
                    return userQuery.Any() ? new UserSession(userQuery.First(), true) : null;
                }
            }

            // deauthenticates the user given by the input session
            public void Deauthenticate(ref UserSession session)
            {
                // gets the sessions authenticated id (possibly null)
                var userId = session?.Identity().AuthenticatedId;
                if (userId == null) return;

                // deauthenticates the current user
                session = new UserSession(userId.GetValueOrDefault(), false);
            }

            // nullifies the input session
            public void Nullify(ref UserSession session)
            {
                session = null;
            }
        }
    }
}
