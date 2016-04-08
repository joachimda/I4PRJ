//========================================================================
// FILENAME :   IAuthenticator.cs
// DESCR.   :   Interface for authenticators
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  AK      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
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