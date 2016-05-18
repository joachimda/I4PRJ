using System;
using System.Collections.Generic;
using System.Globalization;
using Smartpool.Connection.Model;

namespace Smartpool
{
    public interface IDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity);
        void DeleteAllData();
    
        List<Tuple<SensorTypes, double>> GetChlorineValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<SensorTypes, double>> GetTemperatureValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<SensorTypes, double>> GetPhValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<SensorTypes, double>> GetHumidityValues(string poolOwnerEmail, string poolName, int daysToGoBack);
    }
}