//========================================================================
// FILENAME :   UserSession.cs
// DESCR.   :   Class for capturing the user session including
//              user identity and authentication data.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  AK      UserSession interfaced
//========================================================================

using System;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class UserSession : IUserSession
    {
        private readonly Tuple<UserIdentity, bool> _session;

        public UserSession()
        {
            _session = null;
        }

        // this constructor should only be called by an authenticating class
        public UserSession(UserIdentity userId, bool authenticated)
        {
            _session = Tuple.Create(userId, authenticated);
        }

        public bool Authenticated()
        {
            // returns true if user is authenticated
            return _session != null && _session.Item2;
        }

        public UserIdentity Identity()
        {
            // returns the user identity object (possibly null)
            return _session?.Item1;
        }
    }
}