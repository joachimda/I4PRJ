//========================================================================
// FILENAME :   PoolLoader.cs
// DESCR.   :   Model for loading and parsing pool names
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class PoolLoader
    {
        private Session _session = Session.SharedSession;

        public void ReloadPools(IClientMessager clientMessager)
        {
            // Send request to server
            var poolRequest = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString, true);
            var response = clientMessager.SendMessage(poolRequest);
            var poolResponse = response as GetPoolDataResponseMsg;

            // Store pools in session
            if (poolResponse != null)
            {
                _session.Pools = poolResponse.AllPoolNamesListTuple;
            }
        }

        public List<Tuple<SensorType, double>> GetSensorDataFromCurrentPool(IClientMessager clientMessager)
        {
            // Send request to server
            var request = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString);
            var response = (GetPoolDataResponseMsg) clientMessager.SendMessage(request);
            var sensorData = new List<Tuple<SensorType, double>>();

            // MISSING, server support
            sensorData.Add(new Tuple<SensorType, double>(SensorType.Temperature, 34.0));
            sensorData.Add(new Tuple<SensorType, double>(SensorType.Ph, 7.0));
            sensorData.Add(new Tuple<SensorType, double>(SensorType.Chlorine, 2.2));
            sensorData.Add(new Tuple<SensorType, double>(SensorType.Humidity, 50.0));

            return sensorData;
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
