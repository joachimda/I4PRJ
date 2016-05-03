using System.Collections.Generic;
using System.Timers;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public class FakePool
    {
        private readonly int _amountOfSensors;
        private readonly List<FakeSensor> _fakeSensors;

        public FakePool(int amountOfSensors, int secondsBetweenSensorReadings)
        {
            _amountOfSensors = amountOfSensors;
            _fakeSensors = new List<FakeSensor>();
            GenerateSensors();
            var timer = new Timer { Interval = 1000 * secondsBetweenSensorReadings };
            timer.Elapsed += SaveSensorValue;
            timer.Start();
        }

        private void GenerateSensors()
        {
            for (int i = 0; i < _amountOfSensors; i++)
            {
                _fakeSensors.Add(new FakeSensor());
                System.Threading.Thread.Sleep(20);
            }
        }

        private void SaveSensorValue(object sender, ElapsedEventArgs e)
        {
            foreach (var sensor in _fakeSensors)
            {
                sensor.GetNextSensorValue();
                sensor.SaveValueToDatabase();
            }
        }
    }
}
