//========================================================================
// FILENAME :   EditUserViewController.cs
// DESCR.   :   Default implementation of the edit user view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Linq;
using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class EditUserViewController : IEditUserViewController
    {
        // Properties

        private readonly IClientMessenger _clientMessenger;
        private readonly IEditUserView _view;
        private string _oldPassword = "";
        private Session _session = Session.SharedSession;
        public UserValidator User = new UserValidator();

        // Life Cycle
        public void ViewDidLoad()
        {
            // Set initial view conditions
            _view.ClearAllText();
            _view.SetSaveButtonEnabled(false);
            _view.SetNewPasswordValid(false);
        }

        public EditUserViewController(IEditUserView view, IClientMessenger clientMessenger = null)
        {
            _view = view;
            _clientMessenger = clientMessenger;
        }

        // Interface

        public void SaveButtonPressed()
        {
            Save();
        }

        public void DidChangeOldPasswordText(string text)
        {
            _oldPassword = text;
            UpdateSaveButton();
        }

        public void DidChangeNewPasswordText(string text, int fieldNumber)
        {
            if (fieldNumber > 1) throw new ArgumentException();
            User.Passwords[fieldNumber] = text;
            UpdatePassword();
            UpdateSaveButton();
        }

        // LoginViewController

        public void UpdatePassword()
        {
            _view.SetNewPasswordValid(User.PasswordIsValid);
        }

        public void UpdateSaveButton()
        {
            // Enable button if user entered password, name and email
            _view.SetSaveButtonEnabled(User.PasswordIsValid && _oldPassword.Length > 0);
        }

        public void Save()
        {
            // Send message to client
            var updatePasswordRequest = new ChangePasswordRequestMsg(_session.UserName, _session.TokenString, _oldPassword, User.Passwords.First());
            var response = (GeneralResponseMsg) _clientMessenger.SendMessage(updatePasswordRequest);

            if (response.RequestExecutedSuccesfully)
            {
                _view.UpdateSuccessful();
            }
            else
            {
                _view.DisplayAlert("Save Error", response.MessageInfo);
            }
        }
    }
}
