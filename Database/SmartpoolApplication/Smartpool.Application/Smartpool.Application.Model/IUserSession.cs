//========================================================================
// FILENAME :   UserSession.cs
// DESCR.   :   Class for capturing the user session including
//              user identity and authentication data.
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
    public interface IUserSession
    {
        bool Authenticated();
        UserIdentity Identity();
    }
}
