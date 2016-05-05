using System.Collections.Generic;

namespace Smartpool.DataAccess
{
    public interface IWriteDataAccess
    {
        bool CreateTemperatureEntry(string serialNumber, int temperature);
    }

    public interface IReadDataAccess
    {
        List<Temperature> GetRecentTemperatures(string serialNumber, int howManyToReturns);
    }
}