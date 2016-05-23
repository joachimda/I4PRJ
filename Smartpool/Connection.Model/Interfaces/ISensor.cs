using System.Collections.Generic;

namespace Smartpool.Connection.Model
{
    public interface ISensor
    {
        SensorTypes SensorType { get; }
        List<double> SensorValueList { get; }
        void GetNextSensorValue();
        double LastSensorValueEntry { get; }
    }
}