//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Now conforms to the IViewController interface and injects
//              client during construction
// 1.2  LP      Updated to use pool validator
//========================================================================

using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class LoginViewController : ILoginViewController
    {
        // Properties

        private readonly IClientMessenger _clientMessenger;
        private readonly ILoginView _view;
        public UserValidator User = new UserValidator();

        // Life Cycle
        public void ViewDidLoad()
        {
            // Reset text boxes
            _view.SetEmailText("");
            _view.SetPasswordText("");

            // Disable login button
            _view.SetLoginButtonEnabled(false);
        }

        public LoginViewController(ILoginView view, IClientMessenger clientMessenger = null)
        {
            _view = view;
            _clientMessenger = clientMessenger;
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
            // Update the user validator and login button state
            User.Email = text;
            UpdateLoginButton();
        }

        public void DidChangePasswordText(string text)
        {
            // Update the user validator and login button state
            User.Passwords[0] = text;
            UpdateLoginButton();
        }

        // LoginViewController

        public void UpdateLoginButton()
        {
            _view.SetLoginButtonEnabled(User.IsValidForLogin);
        }

        public void Login()
        {
            // Create a new login command
            var request = new LoginRequestMsg(User.Email, User.Passwords[0]);
            var response = _clientMessenger.SendMessage(request);
            var loginResponse = (LoginResponseMsg) response;

            if (loginResponse.LoginSuccessful)
            {
                // Save token
                var session = Session.SharedSession;
                session.TokenString = loginResponse.TokenString;
                session.UserName = User.Email;

                // Notify view
                _view.LoginAccepted (); 
            }
            else {
                // Reset password and display message
                _view.SetPasswordText("");
                _view.DisplayAlert("Login Error", loginResponse.MessageInfo);
            }
        }
    }
}

