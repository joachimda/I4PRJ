using System;
using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public interface IWriteDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity);
        bool RemoveData(string ownerEmail, string poolName);
        bool DeleteAllData();
    }

    public interface IReadDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        List<Tuple<long, double>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, long queryStartHour);
        List<Tuple<long, double>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, long queryStartHour);
    }
}