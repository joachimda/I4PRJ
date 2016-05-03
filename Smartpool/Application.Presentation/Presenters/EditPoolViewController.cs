//========================================================================
// FILENAME :   EditPoolViewController.cs
// DESCR.   :   Default implementation of the edit pool view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class EditPoolViewController : IEditPoolViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager;
        private readonly IEditPoolView _view;
        private Pool _pool = new Pool();
        private string[] _dimensions = { "", "", "" };

        // Life Cycle
        public void ViewDidLoad()
        {
            // Disable add pool button
            _view.SetSaveButtonEnabled(true);
        }

        public EditPoolViewController(IEditPoolView view, IClientMessager clientMessager = null)
        {
            // Stored injected dependencies
            _view = view;
            _clientMessager = clientMessager;
        }

        // Interface

        public void SaveButtonPressed()
        {
            var userName = Session.SharedSession.UserName;
            var tokenString = Session.SharedSession.TokenString;

            // NOTE: Pool address parameter is redundant // MISSING SERIALNUMBER?
            var updatePoolMessage = new UpdatePoolRequestMsg(userName, tokenString, "oldPoolName", "redundant", _pool.Name, _pool.Volume);

            var response = _clientMessager.SendMessage(updatePoolMessage);
            var addPoolResponse = (GeneralResponseMsg)response;

            // Act on response
            if (addPoolResponse.RequestExecutedSuccesfully)
            {
                _view.PoolUpdated();
            }
            else if (addPoolResponse.TokenStillActive == false)
            {
                _view.DisplayAlert("Invalid action", "Your login is no longer active, please login again.");
            }
        }

        public void DidChangeText(EditPoolTextField textField, string text)
        {
            // Switch based on text field type and set the proper variable
            switch (textField)
            {
                case EditPoolTextField.PoolName:
                    _pool.Name = text;
                    break;
                case EditPoolTextField.Volume:
                    _pool.UpdateVolume(text, null);
                    _dimensions[0] = "";
                    _dimensions[1] = "";
                    _dimensions[2] = "";
                    break;
                case EditPoolTextField.Width:
                    _dimensions[0] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
                case EditPoolTextField.Length:
                    _dimensions[1] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
                case EditPoolTextField.Depth:
                    _dimensions[2] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
            }

            // Update the pool button state since input could have changed the expected state
            UpdateSaveButton();
        }

        // LoginViewController

        private void UpdateSaveButton()
        {
            _view.SetSaveButtonEnabled(_pool.IsValid());
        }
    }
}
