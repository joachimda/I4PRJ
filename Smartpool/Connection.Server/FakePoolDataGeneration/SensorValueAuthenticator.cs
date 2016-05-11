﻿using System;
using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal class SensorValueAuthenticator
    {
        private const double MinTemp = -273.15;
        private const double MaxTemp = 100;
        private const double MinPh = 1;
        private const double MaxPh = 14;
        private const double MinChlor = 0;
        private const double MaxChlor = 10;
        private const double MinHum = 0;
        private const double MaxHum = 100;

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