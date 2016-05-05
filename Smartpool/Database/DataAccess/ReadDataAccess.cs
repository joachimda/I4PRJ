using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public class ReadDataAccess : IReadDataAccess
    {
        public List<Temperature> GetRecentTemperatures(string serialNumber, int howManyToReturns)
        {
            throw new System.NotImplementedException();
        }
    }
}