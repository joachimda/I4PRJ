//========================================================================
// FILENAME :   EditPoolViewController.cs
// DESCR.   :   Default implementation of the edit pool view presenter
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
    public class EditPoolViewController : IEditPoolViewController
    {
        // Properties

        private readonly IClientMessager _clientMessager;
        private readonly IEditPoolView _view;
        private string[] _dimensions = { "", "", "" };
        public PoolValidator Pool = new PoolValidator();

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
            if (!Pool.IsValid()) return;

            // NOTE: MISSING SERIALNUMBER?
            var session = Session.SharedSession;
            var updatePoolMessage = new UpdatePoolRequestMsg(session.UserName, session.TokenString, session.SelectedPool.Item1, Pool.Name, Pool.Volume);
            var response = (GeneralResponseMsg) _clientMessager.SendMessage(updatePoolMessage);

            // Act on response
            if (response.RequestExecutedSuccesfully)
            {
                _view.PoolUpdated();
            }
            else if (response.TokenStillActive == false)
            {
                _view.DisplayAlert("Invalid action", "Your login is no longer active, please login again.");
            }
        }

        public void DeleteButtonPressed()
        {
            // Request deletion from server
            var session = Session.SharedSession;
            var request = new RemovePoolRequestMsg(session.UserName, session.TokenString,
                session.SelectedPool.Item1);
            var response = (GeneralResponseMsg) _clientMessager.SendMessage(request);

            // Display a message in the view based on the response
            if (response.RequestExecutedSuccesfully)
            {
                _view.DisplayAlert("Charizard", "The pool was removed succesfully");
            }
            else
            {
                _view.DisplayAlert("Error", "The pool could not be removed");
            }
        }

        public void DidChangeText(EditPoolTextField textField, string text)
        {
            // Switch based on text field type and set the proper variable
            switch (textField)
            {
                case EditPoolTextField.PoolName:
                    Pool.Name = text;
                    break;
                case EditPoolTextField.Volume:
                    Pool.UpdateVolume(text, null);
                    _dimensions[0] = "";
                    _dimensions[1] = "";
                    _dimensions[2] = "";
                    break;
                case EditPoolTextField.Width:
                    _dimensions[0] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
                case EditPoolTextField.Length:
                    _dimensions[1] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
                case EditPoolTextField.Depth:
                    _dimensions[2] = text;
                    Pool.UpdateVolume(null, _dimensions);
                    break;
            }

            // Update the pool button state since input could have changed the expected state
            UpdateSaveButton();
        }

        public void DidSelectPool(string name)
        {
            // Parse the name in the pool loader 
            var loader = new PoolLoader();
            Session.SharedSession.SelectedPoolIndex = loader.IndexForPoolName(name);
        }

        // LoginViewController

        private void UpdateSaveButton()
        {
            _view.SetSaveButtonEnabled(Pool.IsValid());
        }
    }
}
