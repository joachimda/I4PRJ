﻿//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Now conforms to the IViewController interface and injects
//              authenticator during construction
//========================================================================

using Smartpool.Application.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class LoginViewController : ILoginViewController
    {
        // Properties

        private readonly ILoginView _view;
        private readonly IAuthenticator _authenticator;
        private string _password;
        private string _email;

        // Life Cycle
        public void ViewDidLoad()
        {
            // Reset text boxes
            _view.SetEmailText("");
            _view.SetPasswordText("");

            // Disable login button
            _view.SetLoginButtonEnabled(false);
        }

        public void LoadView()
        {
            // 
        }

        public void UnloadView()
        {
            //
        }

        public LoginViewController(ILoginView view)
        {
            _view = view;
            _authenticator = null;
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
            var session = _authenticator?.Authenticate(_email, _password);

            if (session != null && session.Authenticated())
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