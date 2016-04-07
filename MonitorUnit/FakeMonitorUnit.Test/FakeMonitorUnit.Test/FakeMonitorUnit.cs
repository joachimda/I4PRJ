using System;

namespace FakeMonitorUnit.Test
{
    class FakeMonitorUnit : IMonitorUnit
    {
        private double prevPh = 7, prevChlorine = 4, prevTemp = 24, prevHumidity = 70;
        public double GetPhData()
        {
            Random rnd = new Random();
            var val = rnd.Next(1, 14);

            while (prevPh < val - 1 || prevPh > val + 1)
            {
                val = rnd.Next(1, 14);
            }
            prevPh = val;
            return val;
        }

        public double GetChlorineData()
        {
            Random rnd = new Random();
            var val = rnd.Next(0, 10);

            while (prevChlorine < val - 1 || prevChlorine > val + 1)
            {
                val = rnd.Next(0, 10);
            }
            prevChlorine = val;
            return val;
        }

        public double GetHumidityData()
        {

            Random rnd = new Random();
            var val = rnd.Next(0, 100);

            while (prevHumidity < val - 2 || prevHumidity > val + 2)
            {
                val = rnd.Next(0, 100);
            }

            prevHumidity = val;
            return val;
        }

        public double GetTemperatureData()
        {
            Random rnd = new Random();
            var val = rnd.Next(12, 35);

            while (prevTemp < val - 1 || prevTemp > val + 1)
            {
                val = rnd.Next(12, 35);
            }
            prevTemp = val;
                return val;
        }
    }
}