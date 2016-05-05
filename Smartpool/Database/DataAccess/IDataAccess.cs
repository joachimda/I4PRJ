using System;
using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public interface IWriteDataAccess
    {
        bool CreateTemperatureEntry(string poolOwnerEmail, string poolName, int temperature);
    }

    public interface IReadDataAccess
    {
        Dictionary<DateTime, Temperature> GetRecentTemperatures(string poolOwnerEmail, string poolName, int howManyToReturns);
    }
}