//========================================================================
// FILENAME :   StatViewController.cs
// DESCR.   :   Default implementation of the stat view presenter
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  LP      Initial version, missing some implementation
// 1.0  LP      Missing implementation added
// 1.1  LP      Changed DidSelectPool to int and added SetSelected... in
//              ViewDidLoad
//========================================================================

using System;
using Smartpool.Application.Model;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public class StatViewController : IStatViewController
    {
        // Properties

        private readonly IClientMessenger _clientMessenger;
        private readonly IStatView _view;
        private Session _session = Session.SharedSession;
        private PoolLoader _loader = new PoolLoader();

        // Life Cycle
        public void ViewDidLoad()
        {
            // Load pools from server
            _loader.ReloadPools(_clientMessenger);

            // Load active pool info into text fields
            if (!_loader.PoolsAreAvailable())
            {
                _view.DisplayAlert("No pools available", "You have not added any pools yet. Please go to 'Add Pool' to add a pool.");
            }
            else
            {
                _view.SetAvailablePools(_session.Pools);
                _view.SetSelectedPoolIndex(_session.SelectedPoolIndex);
                LoadSensorData();
            }
        }

        public StatViewController(IStatView view, IClientMessenger clientMessenger = null)
        {
            // Stored injected dependencies
            _view = view;
            _clientMessenger = clientMessenger;
        }

        // Interface
        public void DidSelectPool(int index)
        {
            // Parse the name in the pool loader 
            _session.SelectedPoolIndex = index;
            LoadSensorData();
        }

        // EditPoolViewController

        private void LoadSensorData()
        {
            // Loads current sensor data into the view
            _view.DisplaySensorData(_loader.GetCurrentDataFromPool(_clientMessenger));
        }
    }
}
