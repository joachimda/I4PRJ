//========================================================================
// FILENAME :   UserIdentity.cs
// DESCR.   :   Class for capturing the users identity.
//              Needed by user session to be able to explicitly nullify
//              the userId if needed, instead of assigning an arbitrary
//              integer value.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

namespace ModelFirstSmartPool
{
    namespace Authentication
    {
        internal class UserIdentity
        {
            public int AuthenticatedId { get; private set; }

            // this constructor should only be called by an authenticating class
            public UserIdentity(int userId)
            {
                AuthenticatedId = userId;
            }
        }
    }  
}