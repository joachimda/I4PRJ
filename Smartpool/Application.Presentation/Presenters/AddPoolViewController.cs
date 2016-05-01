//========================================================================
// FILENAME :   LoginViewController.cs
// DESCR.   :   Default implementation of the login view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Now conforms to the IViewController interface and injects
//              authenticator during construction
//========================================================================

using System;
using System.Collections.Generic;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class AddPoolViewController : IAddPoolViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager; // temporary, needs a real IClient
        private readonly IAddPoolView _view;
        private string _poolName = "";
        private string _serialNumber = "";
        private string _volume = "";
        private string[] _dimensions = {"", "", ""};
        private double _actualVolume = 0;

        // Life Cycle
        public void ViewDidLoad()
        {
            // Disable add pool button
            _view.SetAddPoolButtonEnabled(false);
        }

        public AddPoolViewController(IAddPoolView view, IClientMessager clientMessager = null)
        {
            _view = view;
            _clientMessager = clientMessager;
        }

        // Interface

        public void AddPoolButtonPressed()
        {
            // Awaiting no
            _view.DisplayAlert("You found a shiny Magikarp!", "Splash, splash...");
        }

       public void DidChangeText(AddPoolTextField textField, string text)
        {
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

            UpdateAddPoolButton();
        }

        // LoginViewController

        private void CalculateVolume(bool userSpecifiedVolume)
        {
            if (userSpecifiedVolume)
            {
                _dimensions[0] = "";
                _dimensions[1] = "";
                _dimensions[2] = "";

                try
                {
                    _actualVolume = double.Parse(_volume);
                }
                catch (Exception)
                {
                    _actualVolume = 0;
                }
            }
            else
            {
                _volume = "";

                try
                {
                    _actualVolume = double.Parse(_dimensions[0]) * double.Parse(_dimensions[1]) * double.Parse(_dimensions[2]);
                }
                catch (Exception)
                {
                    _actualVolume = 0;
                }
            }
        }

        private void UpdateAddPoolButton()
        {
            _view.SetAddPoolButtonEnabled(ShouldEnableAddPoolButton());
        }

        private bool ShouldEnableAddPoolButton()
        {
            if (_poolName.Length == 0) return false;
            if (_serialNumber.Length == 0) return false;
            if (_volume.Length != 0) return true;
            return _dimensions[0].Length != 0 || _dimensions[1].Length != 0 || _dimensions[2].Length != 0;
        }
    }
}
