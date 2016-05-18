using System;
using System.Collections.Generic;
using System.Globalization;

namespace Smartpool
{
    public interface IDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity);
        void DeleteAllData();
    
        List<Tuple<string, double>> GetChlorineValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<string, double>> GetTemperatureValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<string, double>> GetPhValues(string poolOwnerEmail, string poolName, int daysToGoBack);
        List<Tuple<string, double>> GetHumidityValues(string poolOwnerEmail, string poolName, int daysToGoBack);
    }
}