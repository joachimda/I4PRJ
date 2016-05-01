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
	/// <summary>
	/// Enumeration of possible buttons on the Login View
	/// </summary>
    public enum LoginViewButton : int
    {
        LoginButton = 0,
        SignUpButton = 1,
        ForgotButton = 2
    }

    public interface ILoginViewController : IViewController
    {
		/// <summary>
		/// Called by the Login View when a button is pressed
		/// </summary>
        void ButtonPressed(LoginViewButton button);

		/// <summary>
		/// Called by the Login View when the email text field changed
		/// </summary>
        void DidChangeEmailText(string text);

		/// <summary>
		/// Called by the Login View when the password text field changed
		/// </summary>
        void DidChangePasswordText(string text);
    }
}
