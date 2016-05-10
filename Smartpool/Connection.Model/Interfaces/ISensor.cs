namespace Smartpool.Connection.Model
{
    public interface ISensor
    {
        FakeSensorEnum SensorType { get; }
        double SensorValue { get; }
        void GetNextSensorValue();
        void SaveValueToDatabase();
    }
}