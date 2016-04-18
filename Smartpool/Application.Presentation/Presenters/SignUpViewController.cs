//========================================================================
// FILENAME :   SignUpViewController.cs
// DESCR.   :   Default implementation of the sign up view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class SignUpViewController : ISignUpViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager; // temporary, needs a real IClient
        private readonly ISignUpView _view;
        private string _name = "";
        private string[] _passwords = {"", ""};
        private string _email = "";
        private bool _passwordValid = false;

        // Life Cycle
        public void ViewDidLoad()
        {
            // Reset text boxes
            _view.SetNameText("");
            _view.SetEmailText("");
            _view.SetPasswordText("");

            // Disable login button
            _view.SetPasswordValid(false);
            _view.SetButtonEnabled(false);
        }

        public SignUpViewController(ISignUpView view, IClientMessager clientMessager = null)
        {
            _view = view;
            _clientMessager = clientMessager;
        }

        // Interface

        public void ButtonPressed()
        {
            SignUp();
        }

        public void DidChangeNameText(string text)
        {
            _name = text;
            UpdateSignUpButton();
        }

        public void DidChangeEmailText(string text)
        {
            _email = text;
            UpdateSignUpButton();
        }

        public void DidChangePasswordText(string text, int fieldNumber)
        {
            if (fieldNumber > 1) throw new ArgumentException();

            // Store the password text
            _passwords[fieldNumber] = text;

            UpdatePassword();
            UpdateSignUpButton();
        }

        // LoginViewController

        public void UpdatePassword()
        {
            var password = _passwords[0];
            var minimumCharacters = 6;
            if (password == _passwords[1] && password.Length >= minimumCharacters)
            {
                _passwordValid = true;
            }
            else
            {
                _passwordValid = false;
            }
            _view.SetPasswordValid(_passwordValid);
        }

        public void UpdateSignUpButton()
        {
            // Enable button if user entered password, name and email
            if (_passwordValid && _email.Length > 0 && _name.Length > 0)
            {
                _view.SetButtonEnabled(true);
            }
            else {
                _view.SetButtonEnabled(false);
            }
        }

        public void SignUp()
        {
            // Missing implementation
            var successful = false;
            if (successful)
            {
                _view.SignUpAccepted();
            }
            else
            {
                _view.DisplayAlert("Invalid Sign Up", "The e-mail is already used");
            }
        }
    }
}
