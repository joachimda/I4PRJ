using System;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal class SensorValueAuthenticator : ISensorValueAuthenticator
    {
        private const double MinTemp = 20;
        private const double MaxTemp = 40;
        private const double MinPh = 6;
        private const double MaxPh = 9;
        private const double MinChlor = 0;
        private const double MaxChlor = 6;
        private const double MinHum = 30;
        private const double MaxHum = 70;

        public double Auth(SensorTypes sensorType, double sensorValue)
        {
            switch (sensorType)
            {
                case SensorTypes.Temperature:
                    if (sensorValue < MinTemp)
                        sensorValue = MinTemp;
                    if (sensorValue > MaxTemp)
                        sensorValue = MaxTemp;
                    break;
                case SensorTypes.Ph:
                    if (sensorValue < MinPh)
                        sensorValue = MinPh;
                    if (sensorValue > MaxPh)
                        sensorValue = MaxPh;
                    break;
                case SensorTypes.Chlorine:
                    if (sensorValue < MinChlor)
                        sensorValue = MinChlor;
                    if (sensorValue > MaxChlor)
                        sensorValue = MaxChlor;
                    break;
                case SensorTypes.Humidity:
                    if (sensorValue < MinHum)
                        sensorValue = MinHum;
                    if (sensorValue > MaxHum)
                        sensorValue = MaxHum;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sensorType), sensorType, null);
            }
            return sensorValue;
        }
    }
}