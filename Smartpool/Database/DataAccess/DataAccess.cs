using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public bool CreateChlorineEntry(string poolOwnerEmail, string poolName, int chlorineValue)
        {
            throw new NotImplementedException();
        }

        public bool CreateTemperatureEntry(string poolOwnerEmail, string poolName, int temperatureValue)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, Temperature> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int howManyToReturns)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, Temperature> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int howManyToReturns)
        {
            throw new NotImplementedException();
        }
    }
}