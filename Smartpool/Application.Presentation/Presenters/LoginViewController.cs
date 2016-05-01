//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Now conforms to the IViewController interface and injects
//              client during construction
//========================================================================

using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class LoginViewController : ILoginViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager;
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

        public LoginViewController(ILoginView view, IClientMessager clientMessager = null)
        {
            _view = view;
            _clientMessager = clientMessager;
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
                    _view.DisplayAlert("Invalid action", "Please don't do that again.");
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
            // Create a new login command
            var request = new LoginRequestMsg(_email, _password);
            var response = _clientMessager.SendMessage(request);
            var loginResponse = (LoginResponseMsg) response;

            if (loginResponse.LoginSuccessful)
            {
				_view.LoginAccepted ();
                // Save token
            }
            else {
                // Reset password and display message
                _view.SetPasswordText("");
                _view.DisplayAlert("Invalid username or password", "Please try again.");
            }
        }
    }
}
