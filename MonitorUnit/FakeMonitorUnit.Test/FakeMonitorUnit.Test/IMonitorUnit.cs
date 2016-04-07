using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMonitorUnit.Test
{
    public interface IMonitorUnit
    {
        double GetPhData();
        double GetChlorineData();
        double GetHumidityData();
    }

    class FakeMonitorUnit : IMonitorUnit
    {
        public double GetPhData()
        {
            Random rnd = new Random();

            var val = rnd.Next(1, 14);
            return val;
        }

        public double GetChlorineData()
        {
            Random rnd = new Random();
            var val = rnd.Next(100, 1000);
            return val;
        }

        public double GetHumidityData()
        {
            Random rnd = new Random();
            var val = rnd.Next(0, 100);
            return val;
        }
    }
}
