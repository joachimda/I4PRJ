using System;
using System.Collections.Generic;
using System.Linq;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal class FakeSensor : ISensor
    {
        public SensorTypes SensorType { get; set; }
        public List<double> SensorValueList => _sensorValueQueue.ToList();

        private readonly ISensorValueAuthenticator _sensorValueAuthenticator = new SensorValueAuthenticator();
        private readonly Random _random = new Random();
        private readonly Queue<double> _sensorValueQueue = new Queue<double>();
        public double LastSensorValueEntry { get; set; }
        private readonly int _maxHistory;

        public FakeSensor(int sensorType = -1, int maxHistory = 30)
        {
            _maxHistory = maxHistory;
            if (sensorType == -1)
                SensorType = (SensorTypes)_random.Next(0, Enum.GetNames(typeof(SensorTypes)).Length);
            else
                SensorType = (SensorTypes) sensorType;
            
            AddNewSensorValue(GetRandomSensorValue());
        }
        private double GetRandomSensorValue()
        {
            switch (SensorType)
            {
                case SensorTypes.Temperature:
                    return 25 + _random.Next(0, 11); //returns random value between 25 -> 35 with 1.0 precision

                case SensorTypes.Chlorine:
                    return 0 + _random.Next(0, 21) * 0.1; //returns random value between 0 -> 2 with 0.1 precision

                case SensorTypes.Ph:
                    return 7 + _random.Next(0, 9) * 0.1; //returns random value between 7 -> 7.8 with 0.1 precision

                case SensorTypes.Humidity:
                    return 40 + _random.Next(0, 31); //returns random value between 40 -> 70 with 1.0 precision

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
       
        public void GetNextSensorValue()
        {
            if (SensorType == SensorTypes.Temperature || SensorType == SensorTypes.Humidity)
                AddNewSensorValue(LastSensorValueEntry + _random.Next(-2, 3));

            if (SensorType == SensorTypes.Chlorine || SensorType == SensorTypes.Ph)
                AddNewSensorValue(LastSensorValueEntry + _random.Next(-2, 3) * 0.1);
        }

        private void AddNewSensorValue(double sensorValue)
        {
            if (!(_sensorValueQueue.Count < _maxHistory))
                _sensorValueQueue.Dequeue();

            var controlledValue = Math.Round(_sensorValueAuthenticator.Auth(SensorType, sensorValue), 1);
            _sensorValueQueue.Enqueue(controlledValue);
            LastSensorValueEntry = controlledValue;
        }
    }
}