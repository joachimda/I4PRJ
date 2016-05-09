//========================================================================
// FILENAME :   ISignUpView.cs
// DESCR.   :   Interface for sign up views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ISignUpView : IView, IAlertDisplaying
    {
        /// <summary>
        /// Sets the text of the name text field
        /// </summary>
        void SetNameText(string text);

        /// <summary>
        /// Sets the text of the email text field
        /// </summary>
        void SetEmailText(string text);

        /// <summary>
        /// Sets the text of both of the password text fields
        /// </summary>
        void SetPasswordText(string text);

        /// <summary>
        /// Sets the state of the login button
        /// </summary>
        void SetPasswordValid(bool valid);

        /// <summary>
        /// Sets the state of the login button
        /// </summary>
        void SetButtonEnabled(bool enabled);

        /// <summary>
        /// Tells the view that a login request has been accepted, should present the main menu
        /// </summary>
        void SignUpAccepted();
    }
}