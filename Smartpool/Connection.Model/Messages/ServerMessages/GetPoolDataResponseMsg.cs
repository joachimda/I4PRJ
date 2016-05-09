using System.Collections.Generic;

namespace Smartpool.Connection.Model
{
    public class GetPoolDataResponseMsg : ServerMsg
    {
        public List<ISensor> SensorList { get; set; }

        public GetPoolDataResponseMsg(List<ISensor> sensorList)
        {
            SensorList = sensorList;
            MsgType = MessageTypes.GetPoolDataResponse;
        }
    }
}