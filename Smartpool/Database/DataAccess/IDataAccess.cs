﻿using System;
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
        List<Tuple<int, Chlorine>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int queryStartDay);
        List<Tuple<int, Temperature>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int queryStartDay);
    }
}