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
        private string _poolName = "";
        private string _serialNumber = "";
        private string _volume = "";
        private string[] _dimensions = {"", "", ""};

        public double ActualVolume { get; private set; }

        // Life Cycle
        public void ViewDidLoad()
        {
            // Disable add pool button
            _view.SetAddPoolButtonEnabled(false);
            ActualVolume = 0;
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

            // NOTE: Pool address parameter is redundant
            var addPoolMessage = new AddPoolMsg(userName, tokenString, _poolName, ActualVolume);
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
                    _poolName = text;
                    break;
                case AddPoolTextField.SerialNumber:
                    _serialNumber = text;
                    break;
                case AddPoolTextField.Volume:
                    _volume = text;
                    CalculateVolume(true);
                    break;
                case AddPoolTextField.Width:
                    _dimensions[0] = text;
                    CalculateVolume(false);
                    break;
                case AddPoolTextField.Length:
                    _dimensions[1] = text;
                    CalculateVolume(false);
                    break;
                case AddPoolTextField.Depth:
                    _dimensions[2] = text;
                    CalculateVolume(false);
                    break;
            }

            // Update the pool button state since input could have changed the expected state
            UpdateAddPoolButton();
        }

        // LoginViewController

        private void CalculateVolume(bool userSpecifiedVolume)
        {
            if (userSpecifiedVolume)
            {
                // Calculating based on volume input so dimensions are redundant
                _dimensions[0] = "";
                _dimensions[1] = "";
                _dimensions[2] = "";
                _view.ClearDimensionText();

                // Try parsing the input string, otherwise set to 0
                try
                {
                    ActualVolume = double.Parse(_volume);
                }
                catch (Exception)
                {
                    ActualVolume = 0;
                }
            }
            else
            {
                // Calculating based on dimensions input so volume is redundant
                _volume = "";
                _view.ClearVolumeText();

                // Try parsing the input string, otherwise set to 0
                try
                {
                    ActualVolume = double.Parse(_dimensions[0]) * double.Parse(_dimensions[1]) * double.Parse(_dimensions[2]);
                }
                catch (Exception)
                {
                    ActualVolume = 0;
                }
            }
        }

        private void UpdateAddPoolButton()
        {
            _view.SetAddPoolButtonEnabled(ShouldEnableAddPoolButton());
        }

        private bool ShouldEnableAddPoolButton()
        {
            // Returns true if a pool name and serial number is specified
            if (_poolName.Length == 0) return false;
            if (_serialNumber.Length == 0) return false;
            return true;
        }
    }
}
