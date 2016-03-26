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

        public List<MonitorUnit> MonitorUnits { get; set; }

        #endregion

        public Pool(string name)
        {
            Name = name;
        }
    }

    public class MonitorUnit
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double Ph { get; set; }
        public double Clorine { get; set; }
    }
}