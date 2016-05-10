namespace Smartpool.Connection.Model
{
    public interface ISensor
    {
        SensorTypes SensorType { get; }
        double SensorValue { get; }
        void GetNextSensorValue();
        void SaveValueToDatabase();
    }
}