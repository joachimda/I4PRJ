//========================================================================
// FILENAME :   ILoginViewController.cs
// DESCR.   :   Interface for login view presenters
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public enum LoginViewButton : int
    {
        LoginButton = 0,
        SignUpButton = 1,
        ForgotButton = 2
    }

    public interface ILoginViewController : IViewController
    {
        void ButtonPressed(LoginViewButton button);
        void DidChangeEmailText(string text);
        void DidChangePasswordText(string text);
    }
}
