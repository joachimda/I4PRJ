using System.Collections.Generic;
using System.Linq;
using DBAccessV1;

namespace DBAccessV1
{
    public class Pool : IPoolRead, IPoolWrite
    {
        #region Properties

        public string Name { get; set; }

        public double Temperature
        {
            get
            {
                double temp = MonitorUnits.Sum(unit => unit.Temperature);
                return temp/MonitorUnits.Count;
            }
        }

        public double Ph
        {
            get
            {
                double ph = MonitorUnits.Sum(unit => unit.Ph);
                return ph/MonitorUnits.Count;
            }
        }

        public double Clorine
        {
            get
            {
                double clor = MonitorUnits.Sum(unit => unit.Clorine);
                return clor/MonitorUnits.Count;
            }
        }

        public List<IMonitorUnit> MonitorUnits { get; set; }

        #endregion

        public Pool(string name)
        {
            Name = name;
        }

        #region Methods

        public void AddMonitorUnit(IMonitorUnit monitorUnit)
        {
            MonitorUnits.Add(monitorUnit);
        }

        public void RemoveMonitorUnit(int monitorUnitId)
        {
            // find unit with id, and remove
        }

        #endregion
    }
}