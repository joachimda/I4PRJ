//========================================================================
// FILENAME :   AddPoolViewController.cs
// DESCR.   :   Default implementation of the add pool view presenter
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
    public class AddPoolViewController : IAddPoolViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager;
        private readonly IAddPoolView _view;
        private Pool _pool = new Pool();
        private string[] _dimensions = {"", "", ""};

        // Life Cycle
        public void ViewDidLoad()
        {
            // Disable add pool button
            _view.SetAddPoolButtonEnabled(false);
        }

        public AddPoolViewController(IAddPoolView view, IClientMessager clientMessager = null)
        {
            // Stored injected dependencies
            _view = view;
            _clientMessager = clientMessager;
        }

        // Interface

        public void AddPoolButtonPressed()
        {
            var userName = Session.SharedSession.UserName;
            var tokenString = Session.SharedSession.TokenString;

            // NOTE: Pool address parameter is redundant // MISSING SERIALNUMBER?
            var addPoolMessage = new AddPoolMsg(userName, tokenString, "", _pool.Name, _pool.Volume);
            var response = _clientMessager.SendMessage(addPoolMessage);
            var addPoolResponse = (GeneralResponseMsg) response;

            // Act on response
            if (addPoolResponse.RequestExecutedSuccesfully)
            {
                _view.PoolAdded();
            } else if (addPoolResponse.TokenStillActive == false)
            {
                _view.DisplayAlert("Invalid action","Your login is no longer active, please login again.");
            }
        }

       public void DidChangeText(AddPoolTextField textField, string text)
        {
            // Switch based on text field type and set the proper variable
            switch (textField)
            {
                case AddPoolTextField.PoolName:
                    _pool.Name = text;
                    break;
                case AddPoolTextField.SerialNumber:
                    _pool.SerialNumber = text;
                    break;
                case AddPoolTextField.Volume:
                    _pool.UpdateVolume(text, null);
                    _dimensions[0] = "";
                    _dimensions[1] = "";
                    _dimensions[2] = "";
                    break;
                case AddPoolTextField.Width:
                    _dimensions[0] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
                case AddPoolTextField.Length:
                    _dimensions[1] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
                case AddPoolTextField.Depth:
                    _dimensions[2] = text;
                    _pool.UpdateVolume(null, _dimensions);
                    break;
            }

            // Update the pool button state since input could have changed the expected state
            UpdateAddPoolButton();
        }

        // LoginViewController

        private void UpdateAddPoolButton()
        {
            _view.SetAddPoolButtonEnabled(_pool.IsValid());
        }
    }
}
