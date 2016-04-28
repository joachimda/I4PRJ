using System;

namespace FakeMonitorUnit.Test
{
    class FakeMonitorUnit : IMonitorUnit
    {
        private double prevPh = 7, prevChlorine = 4, prevTemp = 24, prevHumidity = 70;
        Random _rnd = new Random();
        
        public double GetPhData()
        {
            double val = _rnd.Next(1, 14);

            while (prevPh < val - 1 || prevPh > val + 1)
            {
                val = _rnd.Next(1, 14);
            }

            prevPh = val;

            return val;
        }

        public double GetChlorineData()
        {
            double val = _rnd.Next(0, 10);

            while (prevChlorine < val - 1 || prevChlorine > val + 1)
            {
                val = _rnd.Next(0, 10);
            }

            prevChlorine = val;

            return val;
        }

        public double GetHumidityData()
        {
            double val = _rnd.Next(0, 100);

            while (prevHumidity < val - 2 || prevHumidity > val + 2)
            {
                val = _rnd.Next(0, 100);
            }

            prevHumidity = val;

            return val;
        }

        public double GetTemperatureData()
        {
            double val = _rnd.Next(12, 35);

            while (prevTemp < val - 1 || prevTemp > val + 1)
            {
                val = _rnd.Next(12, 35);
            }

            prevTemp = val;

                return val;
        }
    }
}