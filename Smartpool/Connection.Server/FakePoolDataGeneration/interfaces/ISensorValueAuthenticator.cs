using Smartpool.Connection.Model;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    internal interface ISensorValueAuthenticator
    {
        double Auth(SensorTypes sensorType, double sensorValue);
    }
}