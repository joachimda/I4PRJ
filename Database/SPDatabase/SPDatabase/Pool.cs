using System.Collections.Generic;

namespace SPDatabase
{
    public class Pool
    {
        #region Properties

        public int PoolId { get; set; }

        private List<MonitorUnit> _monitorUnits;

        public List<MonitorUnit> MonitorUnits
        {
            get { return _monitorUnits; }
            set { _monitorUnits = value; }
        }

        private double _averageTemperature;

        public double AverageTemperature
        {
            get { return _averageTemperature; }
            set { _averageTemperature = value; }
        }


        #endregion

        //public int Depth { get; set; }
        //public int Length { get; set; }
        //public int Width { get; set; }
    }
}