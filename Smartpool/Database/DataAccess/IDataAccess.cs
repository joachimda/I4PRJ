using System;
using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public interface IWriteDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        bool AddData(string ownerEmail, string poolName);
        bool RemoveData(string ownerEmail, string poolName);
        bool DeleteAllData();
        bool CreateChlorineEntry(string poolOwnerEmail, string poolName, int chlorineValue);
        bool CreateTemperatureEntry(string poolOwnerEmail, string poolName, int temperatureValue);
    }

    public interface IReadDataAccess
    {
        IPoolAccess PoolAccess { get; set; }
        List<Tuple<int, double>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int queryStartDay);
        List<Tuple<int, double>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int queryStartDay);
    }
}