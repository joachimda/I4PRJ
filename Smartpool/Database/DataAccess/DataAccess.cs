using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public bool CreateTemperatureEntry(string serialNumber, int temperature)
        {
            throw new System.NotImplementedException();
        }

        public List<Temperature> GetRecentTemperatures(string serialNumber, int howManyToReturns)
        {
            throw new System.NotImplementedException();
        }
    }
}