using System;
using System.Collections.Generic;

namespace Smartpool.Connection.Model
{
    public class GetPoolDataResponseMsg : ServerMsg
    {
        public List<Tuple<SensorTypes, List<double>>> SensorList { get; set; }
        public List<Tuple<string, bool>> AllPoolNamesListTuple { get; set; }

        public GetPoolDataResponseMsg(List<Tuple<SensorTypes, List<double>>> sensorList = null, List<Tuple<string, bool>> allPoolNamesListTuple = null )
        {
            SensorList = sensorList;
            AllPoolNamesListTuple = allPoolNamesListTuple;
            MsgType = MessageTypes.GetPoolDataResponse;
        }
    }
}