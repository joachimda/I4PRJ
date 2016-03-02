using System.Collections.Generic;

namespace SPDatabase
{
    public class Pool : IPool
    {
        #region Properties

        public int PoolId { get; set; }
        public List<MonitorUnit> MonitorUnits { get; set; }
        public double AverageTemperature { get; set; }

        //public int Depth { get; set; }
        //public int Length { get; set; }
        //public int Width { get; set; }

        #endregion


    }
}