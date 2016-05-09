namespace Smartpool.Connection.Model
{
    public interface ISensor
    {
        void GetNextSensorValue();
        void SaveValueToDatabase();
    }
}