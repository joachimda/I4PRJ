using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public class FakePool
    {
        public string UserName { get; set; }
        public string PoolName { get; set; }
        public ISmartpoolDB SmartpoolDb { get; set; }
        private readonly int _amountOfSensors;
        private readonly List<ISensor> _fakeSensors;

        public FakePool(int amountOfSensors, int secondsBetweenSensorReadings, string userName, string poolName, ISmartpoolDB smartpoolDb)
        {
            UserName = userName;
            PoolName = poolName;
            SmartpoolDb = smartpoolDb;
            _amountOfSensors = amountOfSensors;
            _fakeSensors = new List<ISensor>();
            GenerateSensors();
            var timer = new Timer { Interval = 1000 * secondsBetweenSensorReadings };
            timer.Elapsed += SaveSensorValue;
            timer.Start();
        }

        private void GenerateSensors()
        {
            for (int i = 0; i < 4; i++)
            {
                _fakeSensors.Add(new FakeSensor(i));
                System.Threading.Thread.Sleep(20);
            }
            /*random sensors
            for (int i = 0; i < _amountOfSensors; i++)
            {
                _fakeSensors.Add(new FakeSensor());
                System.Threading.Thread.Sleep(20);
            }
            */
        }

        private void SaveSensorValue(object sender, ElapsedEventArgs e)
        {
            foreach (var sensor in _fakeSensors)
            {
                sensor.GetNextSensorValue();
            }
            SaveValueToDatabase();
        }

        private void SaveValueToDatabase()
        {
            SmartpoolDb.DataAccess.CreateDataEntry(UserName, PoolName, _fakeSensors[2].LastSensorValueEntry, _fakeSensors[0].LastSensorValueEntry,
                _fakeSensors[1].LastSensorValueEntry, _fakeSensors[3].LastSensorValueEntry);
        }

        public List<Tuple<SensorTypes, List<double>>> GetSensorValuesList()
        {
            return _fakeSensors.Select(sensor => new Tuple<SensorTypes, List<double>>(sensor.SensorType, sensor.SensorValueList)).ToList();
        }
    }
}
