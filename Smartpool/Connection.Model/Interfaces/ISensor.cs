using System.Collections.Generic;

namespace Smartpool.Connection.Model
{
    public interface ISensor
    {
        SensorTypes SensorType { get; }
        List<double> SensorValuesList();
        void GetNextSensorValue();
        void SaveValueToDatabase();
    }
}