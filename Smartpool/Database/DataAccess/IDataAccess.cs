using System;
using System.Collections.Generic;

namespace Smartpool
{
    public interface IDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity);
        bool RemoveData(string ownerEmail, string poolName);
        bool DeleteAllData();
    
        List<Tuple<string, double>> GetChlorineValues(string poolOwnerEmail, string poolName, string start, string end);
        List<Tuple<string, double>> GetTemperatureValues(string poolOwnerEmail, string poolName, string start, string end);
    }
}