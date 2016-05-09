using System;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal class FakeSensor : ISensor
    {
        private readonly Random _random = new Random();
        public FakeSensorEnum SensorType { get; set; }
        public double SensorValue { get; set; }

        public FakeSensor()
        {
            SensorType = (FakeSensorEnum)_random.Next(0, Enum.GetNames(typeof(FakeSensorEnum)).Length);
            SensorValue = GetRandomSensorValue();
        }
        private double GetRandomSensorValue()
        {
            switch (SensorType)
            {
                case FakeSensorEnum.Temperature:
                    return 25 + _random.Next(0, 11); //returns random value between 25 -> 35 with 1.0 precision

                case FakeSensorEnum.Chlorine:
                    return 0 + _random.Next(0, 21) * 0.1; //returns random value between 0 -> 2 with 0.1 precision

                case FakeSensorEnum.Ph:
                    return 7 + _random.Next(0, 9) * 0.1; //returns random value between 7 -> 7.8 with 0.1 precision

                case FakeSensorEnum.Humidity:
                    return 40 + _random.Next(0, 31); //returns random value between 40 -> 70 with 1.0 precision

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void GetNextSensorValue()
        {
            switch (SensorType)
            {
                case FakeSensorEnum.Temperature:
                    SensorValue += _random.Next(-2, 3);
                    break;

                case FakeSensorEnum.Chlorine:
                    SensorValue += _random.Next(-2, 3) * 0.1;
                    break;

                case FakeSensorEnum.Ph:
                    SensorValue += _random.Next(-2, 3) * 0.1;
                    break;

                case FakeSensorEnum.Humidity:
                    SensorValue += _random.Next(-2, 3);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SaveValueToDatabase()
        {
            Console.WriteLine(DateTime.Now + " - Sensor of type: " + SensorType + " recorded a value of: " + SensorValue);
        }
    }
}