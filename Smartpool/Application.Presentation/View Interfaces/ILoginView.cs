//========================================================================
// FILENAME :   ILoginView.cs
// DESCR.   :   Interface for login views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ILoginView : IView, IAlertDisplaying
    {
		/// <summary>
		/// Sets the text of the email text field
		/// </summary>
        void SetEmailText(string text);

		/// <summary>
		/// Sets the text of the password text field
		/// </summary>
        void SetPasswordText(string text);

		/// <summary>
		/// Sets the state of the login button
		/// </summary>
        void SetLoginButtonEnabled(bool enabled);

		/// <summary>
		/// Tells the view that a login request has been accepted, should present the main menu
		/// </summary>
		void LoginAccepted();
    }
}