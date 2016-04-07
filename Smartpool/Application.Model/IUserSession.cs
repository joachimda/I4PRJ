//========================================================================
// FILENAME :   IUserSession.cs
// DESCR.   :   Interface for user sessions
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  AK      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public interface IUserSession
    {
        bool Authenticated();
        UserIdentity Identity();
    }
}