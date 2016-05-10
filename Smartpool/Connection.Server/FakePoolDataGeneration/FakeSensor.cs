using System;
using System.Collections.Generic;
using System.Linq;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal class FakeSensor : ISensor
    {
        private readonly Random _random = new Random();
        public SensorTypes SensorType { get; set; }

        public List<double> SensorValueList => SensorValueQueue.ToList();

        private Queue<double> SensorValueQueue { get; set; }
        private double _lastSensorValueEntry;
        private readonly int _maxHistory;

        public FakeSensor(int sensorType = -1, int maxHistory = 30)
        {
            _maxHistory = maxHistory;
            SensorValueQueue = new Queue<double>();
            if (sensorType == -1)
                SensorType = (SensorTypes)_random.Next(0, Enum.GetNames(typeof(SensorTypes)).Length);
            else
            {
                SensorType = (SensorTypes) sensorType;
            }
            _lastSensorValueEntry = GetRandomSensorValue();
            SensorValueQueue.Enqueue(_lastSensorValueEntry);
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
            switch (SensorType)
            {
                case SensorTypes.Temperature:
                    AddNewSensorValue(_lastSensorValueEntry + _random.Next(-2, 3));
                    break;

                case SensorTypes.Chlorine:
                    AddNewSensorValue(_lastSensorValueEntry + _random.Next(-2, 3) * 0.1);
                    break;

                case SensorTypes.Ph:
                    AddNewSensorValue(_lastSensorValueEntry + _random.Next(-2, 3) * 0.1);
                    break;

                case SensorTypes.Humidity:
                    AddNewSensorValue(_lastSensorValueEntry + _random.Next(-2, 3));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddNewSensorValue(double nextValue)
        {
            if (!(SensorValueQueue.Count < _maxHistory))
                SensorValueQueue.Dequeue();

            SensorValueQueue.Enqueue(nextValue);
            _lastSensorValueEntry = nextValue;
        }

        public void SaveValueToDatabase()
        {
            //Not implemented
            //Console.WriteLine(DateTime.Now + " - Sensor of type: " + SensorType + " recorded a value of: " + _lastSensorValueEntry);
        }
    }
}