//========================================================================
// FILENAME :   HistoryViewController.cs
// DESCR.   :   Default implementation of the history view presenter
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
    public class HistoryViewController : IHistoryViewController
    {
        // Properties

        private readonly IClientMessenger _clientMessenger;
        private readonly IHistoryView _view;
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
                LoadSensorData();
            }
        }

        public HistoryViewController(IHistoryView view, IClientMessenger clientMessenger = null)
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
            // Loads historic sensor data into the view
            _view.DisplayHistoricData(_loader.GetHistoricDataFromPool(_clientMessenger, 7));
        }
    }
}
