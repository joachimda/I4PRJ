using System.Collections.Generic;

namespace SPDatabase
{
    public interface IPool
    {
        double AverageTemperature { get; set; }
        List<MonitorUnit> MonitorUnits { get; set; }
        int PoolId { get; set; }
    }
}