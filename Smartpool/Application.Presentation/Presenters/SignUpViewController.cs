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
        public UserValidator User = new UserValidator();

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
            User.Name = text;
            UpdateSignUpButton();
        }

        public void DidChangeEmailText(string text)
        {
            User.Email = text;
            UpdateSignUpButton();
        }

        public void DidChangePasswordText(string text, int fieldNumber)
        {
            if (fieldNumber > 1) throw new ArgumentException();

            // Store the password text
            User.Passwords[fieldNumber] = text;
            UpdatePassword();
            UpdateSignUpButton();
        }

        // LoginViewController

        public void UpdatePassword()
        {
            _view.SetPasswordValid(User.PasswordIsValid);
        }

        public void UpdateSignUpButton()
        {
            // Enable button if user entered password, name and email
            _view.SetButtonEnabled(User.IsValidForSignup);
        }

        public void SignUp()
        {
            // send message to client
            var signUpRequest = new AddUserRequestMsg(User.Name, User.Email, User.Passwords[0]);
            var response = _clientMessager.SendMessage(signUpRequest);
            var generalResponse = (GeneralResponseMsg) response;

            if (generalResponse.RequestExecutedSuccesfully)
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
