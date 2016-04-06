//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class LoginViewController : ILoginViewController
    {
        // Properties

        private ILoginView _view;
        private string _password;
        private string _email;

        // Life Cycle

        public LoginViewController(ILoginView view)
        {
            this._view = view;
        }

        // Interface

        public void ButtonPressed(LoginViewButton button)
        {
            switch (button)
            {
                case LoginViewButton.LoginButton:
                    Login();
                    break;
                case LoginViewButton.SignUpButton:
                    break;
                case LoginViewButton.ForgotButton:
                    break;
                default:
                    break;
            }
        }

        public void DidChangeEmailText(string text)
        {
            _email = text;
            UpdateLoginButton();
        }

        public void DidChangePasswordText(string text)
        {
            _password = text;
            UpdateLoginButton();
        }

        // LoginViewController

        private void UpdateLoginButton()
        {

            // Enable button if user entered password and email
            if (_email.Length > 0 && _password.Length > 0)
            {
                _view.SetLoginButtonEnabled(true);
            }
            else {
                _view.SetLoginButtonEnabled(false);
            }
        }

        private void Login()
        {
            var authenticator = new Authenticator();
            var session = authenticator.Authenticate(_email, _password);

            if (session.Authenticated())
            {
                // Present another view controller (MISSING IMPLEMENTATION)
            }
            else {
                // Reset password and display message
                _view.SetPasswordText("");
                _view.DisplayAlert("Invalid username or password", "Please try again.");
            }
        }
    }
}
