//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Now conforms to the IViewController interface and injects
//              authenticator during construction
//========================================================================

using Client;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation.Temp
{
    public class LoginViewController : ILoginViewController
    {
        // Properties

        private readonly ILoginView _view;
        private string _password = "";
        private string _email = "";
     
        // Life Cycle
        public void ViewDidLoad()
        {
            // Reset text boxes
            _view.SetEmailText("");
            _view.SetPasswordText("");

            // Disable login button
            _view.SetLoginButtonEnabled(false);
        }

        public LoginViewController(ILoginView view)
        {
            _view = view;
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

        public void UpdateLoginButton()
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

        public void Login()
        {
            var client = new ClientCommands();
            var accepted = client.Login(_email, _password);

            if (accepted)
            {
				_view.LoginAccepted ();
            }
            else {
                // Reset password and display message
                _view.SetPasswordText("");
                _view.DisplayAlert("Invalid username or password", "Please try again.");
            }
        }
    }
}
