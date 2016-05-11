﻿//========================================================================
// FILENAME :   EditPoolViewController.cs
// DESCR.   :   Default implementation of the edit pool view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Updated to use pool validator and loader
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

        private readonly IClientMessenger _clientMessenger;
        private readonly IEditPoolView _view;
        private string[] _dimensions = { "", "", "" };
        private Session _session = Session.SharedSession;
        private PoolValidator _pool = new PoolValidator();
        private PoolLoader _loader = new PoolLoader();

        // Life Cycle
        public void ViewDidLoad()
        {
            // Load pools from server
            _loader.ReloadPools(_clientMessenger);

            // Load active pool info into text fields
            LoadPoolInfoIntoView();
        }

        public EditPoolViewController(IEditPoolView view, IClientMessenger clientMessenger = null)
        {
            // Stored injected dependencies
            _view = view;
            _clientMessenger = clientMessenger;
        }

        // Interface

        public void SaveButtonPressed()
        {
            if (!_pool.IsValid()) return;

            // NOTE: MISSING SERIALNUMBER?
            var session = Session.SharedSession;
            var updatePoolMessage = new UpdatePoolRequestMsg(session.UserName, session.TokenString, session.SelectedPool.Item1, _pool.Name, _pool.Volume);
            var response = (GeneralResponseMsg) _clientMessenger.SendMessage(updatePoolMessage);

            // Act on the response from the server
            if (response.RequestExecutedSuccesfully)
            {
                _loader.ResetPools(_clientMessenger);
                _view.PoolUpdated();
                LoadPoolInfoIntoView();
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
            var response = (GeneralResponseMsg) _clientMessenger.SendMessage(request);

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

        public void DidSelectPool(int index)
        {
            // Parse the name in the pool loader 
            _session.SelectedPoolIndex = index;
            if (!_loader.PoolsAreAvailable()) return;

            _view.SetNameText(_session.SelectedPool.Item1);
            _view.SetDeleteButtonEnabled(true);
        }

        // EditPoolViewController

        private void UpdateSaveButton()
        {
            _view.SetSaveButtonEnabled(_pool.Name.Length > 0);
        }

        private void LoadPoolInfoIntoView()
        {
            // Load active pool info into text fields
            _view.SetAvailablePools(_session.Pools);

            if (_loader.PoolsAreAvailable())
            {
                _pool.Name = _session.SelectedPool.Item1;
                _pool.SerialNumber = "1X2X5-13ADQ-23AS1-23X1DD-D123Q"; // NOTE
                _view.SetNameText(_session.SelectedPool.Item1);
                _view.SetVolumeText("30"); // NOTE
                _view.SetSelectedPoolIndex(_session.SelectedPoolIndex);
                _view.SetSaveButtonEnabled(true);
                _view.SetDeleteButtonEnabled(true);
            }
            else
            {
                _view.DisplayAlert("No pools", "You have no pools to edit");
                _view.SetSaveButtonEnabled(false);
                _view.SetDeleteButtonEnabled(false);
            }
        }
    }
}
