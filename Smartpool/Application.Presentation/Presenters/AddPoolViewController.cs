//========================================================================
// FILENAME :   AddPoolViewController.cs
// DESCR.   :   Default implementation of the add pool view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Updated to use pool validator
//========================================================================

using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class AddPoolViewController : IAddPoolViewController
    {
        // Properties

        private readonly IClientMessenger _clientMessenger;
        private readonly IAddPoolView _view;
        private string[] _dimensions = {"", "", ""};
        public PoolValidator Pool = new PoolValidator();

        // Life Cycle
        public void ViewDidLoad()
        {
            // Disable add pool button
            _view.SetAddPoolButtonEnabled(false);
        }

        public AddPoolViewController(IAddPoolView view, IClientMessenger clientMessenger = null)
        {
            // Stored injected dependencies
            _view = view;
            _clientMessenger = clientMessenger;
        }

        // Interface

        public void AddPoolButtonPressed()
        {
            if (!Pool.IsValid()) return;

            var userName = Session.SharedSession.UserName;
            var tokenString = Session.SharedSession.TokenString;

            // Send add pool request to server
            var addPoolMessage = new AddPoolRequestMsg(userName, tokenString, Pool.Name, Pool.Volume, Pool.SerialNumber);
            var response = _clientMessenger.SendMessage(addPoolMessage);
            var addPoolResponse = (GeneralResponseMsg) response;

            // Act on response
            if (addPoolResponse.RequestExecutedSuccesfully)
            {
                var loader = new PoolLoader();
                loader.ReloadPools(_clientMessenger);
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
                    Pool.Name = text;
                    break;
                case AddPoolTextField.SerialNumber:
                    Pool.SerialNumber = text;
                    break;
                case AddPoolTextField.Volume:
                    Pool.UpdateVolume(text, null);
                    _dimensions[0] = "";
                    _dimensions[1] = "";
                    _dimensions[2] = "";
                    break;
                case AddPoolTextField.Width:
                    _dimensions[0] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
                case AddPoolTextField.Length:
                    _dimensions[1] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
                case AddPoolTextField.Depth:
                    _dimensions[2] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
            }

            // Update the pool button state since input could have changed the expected state
            UpdateAddPoolButton();
        }

        // LoginViewController

        private void UpdateAddPoolButton()
        {
            _view.SetAddPoolButtonEnabled(Pool.IsValid());
        }
    }
}
