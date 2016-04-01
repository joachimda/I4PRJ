//========================================================================
// FILENAME :   Authenticator.cs
// DESCR.   :   Class for authenticating users and providing them a
//              UserSession to pass on to future service requests
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  AK      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartpool.Application.Model
{
    public interface IAuthenticator
    {
        UserSession Authenticate(string email, string password);
        void Deauthenticate(ref UserSession session);
        void Nullify(ref UserSession session);
        bool ConfirmReadAccess(UserSession session);
        bool ConfirmWriteAccess(UserSession session);
    }
}
