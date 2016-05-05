using System;
using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public bool CreateTemperatureEntry(string poolOwnerEmail, string poolName, int temperature)
        {
            throw new System.NotImplementedException();
        }
        
        Dictionary<DateTime, Temperature> IReadDataAccess.GetRecentTemperatures(string poolOwnerEmail, string poolName, int howManyToReturns)
        {
            throw new NotImplementedException();
        }
    }
}