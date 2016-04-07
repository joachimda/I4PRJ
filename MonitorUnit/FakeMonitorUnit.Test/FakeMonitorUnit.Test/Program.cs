using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FakeMonitorUnit.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMonitorUnit monitor = new FakeMonitorUnit();

            while (true)
            {
                Console.WriteLine("Chlorine level is " + monitor.GetChlorineData() + " units");
                Console.WriteLine("Room humidity is " + monitor.GetHumidityData() + "%");
                Console.WriteLine("pH level is " + monitor.GetPhData());
                Console.WriteLine("Temperature is " + monitor.GetTemperatureData() + " degrees Celcius");
                Thread.Sleep(1000);

            }

        }
    }
}
