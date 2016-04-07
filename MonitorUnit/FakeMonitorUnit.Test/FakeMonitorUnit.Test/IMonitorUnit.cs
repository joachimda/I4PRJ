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
}
