using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public interface ISensorValueAuthenticator
    {
        double Auth(SensorTypes sensorType, double sensorValue);
    }
}