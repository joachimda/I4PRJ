//========================================================================
// FILENAME :   PoolLoader.cs
// DESCR.   :   Model for loading pools into the session and parsing pool
//              names from strings to actual pools
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1  LP      Volume can't be negative
//========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class PoolLoader
    {
        private Session _session = Session.SharedSession;

        public void ReloadPools(IClientMessenger clientMessenger)
        {
            // Send request to server
            var poolRequest = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString, true);
            var response = (GetPoolDataResponseMsg) clientMessenger.SendMessage(poolRequest);

            // Store pools in session
            _session.Pools = response.AllPoolNamesListTuple;
        }

        public void ResetPools(IClientMessenger clientMessenger)
        {
            ReloadPools(clientMessenger);
            _session.SelectedPoolIndex = 0;
        }

        public List<Tuple<SensorTypes, double>> GetCurrentDataFromPool(IClientMessenger clientMessenger)
        {
            // Send request to server
            var request = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString, false, _session.SelectedPool.Item1);
            var response = (GetPoolDataResponseMsg) clientMessenger.SendMessage(request);
            return response.SensorList.Select(sensor => new Tuple<SensorTypes, double>(sensor.Item1, sensor.Item2.LastOrDefault())).ToList();
        }

        public List<Tuple<SensorTypes, List<double>>> GetHistoricDataFromPool(IClientMessenger clientMessenger, int numberOfDays)
        {
            // Send request to server
            var request = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString, false, _session.SelectedPool.Item1, numberOfDays);
            var response = (GetPoolDataResponseMsg)clientMessenger.SendMessage(request);
            return response.SensorList;
        }

        public int IndexForPoolName(string name)
        {
            // Searches for the name among the pools and returns the index
            for (var i = 0; i < _session.Pools.Count; i++)
            {
                if (_session.Pools[i].Item1 == name) return i;
            }
            return 0;
        }

        public bool PoolsAreAvailable()
        {
            // Returns true if pools are loaded
            return _session.Pools.Count > 0;
        }
    }
}
