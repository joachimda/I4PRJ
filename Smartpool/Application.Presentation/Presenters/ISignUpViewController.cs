//========================================================================
// FILENAME :   ISignUpViewController.cs
// DESCR.   :   Interface for sign up view presenters
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ISignUpViewController : IViewController
    {
        /// <summary>
        /// Called by the Sign Up View when the sign up button is pressed
        /// </summary>
        void ButtonPressed();

        /// <summary>
        /// Called by the Sign Up View when the name text field changed
        /// </summary>
        void DidChangeNameText(string text);

        /// <summary>
        /// Called by the Sign Up View when the email text field changed
        /// </summary>
        void DidChangeEmailText(string text);

        /// <summary>
        /// Called by the Sign Up View when either of the the password text fields changed
        /// </summary>
        void DidChangePasswordText(string text, int fieldNumber);
    }
}
