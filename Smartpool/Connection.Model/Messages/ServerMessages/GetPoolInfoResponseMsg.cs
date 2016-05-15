namespace Smartpool.Connection.Model
{
    public class GetPoolInfoResponseMsg : ServerMsg
    {
        public double Volume { get; set; }
        public string SerialNumber { get; set; }

        public GetPoolInfoResponseMsg(double volume, string serialNumber)
        {
            Volume = volume;
            SerialNumber = serialNumber;
            MsgType = MessageTypes.GetPoolInfoResponse;
        }
    }
}