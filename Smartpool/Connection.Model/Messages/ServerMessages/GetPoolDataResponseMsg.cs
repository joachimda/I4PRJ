namespace Smartpool.Connection.Model
{
    public class GetPoolDataResponseMsg : ServerMsg
    {
        public GetPoolDataResponseMsg()
        {
            MsgType = MessageTypes.GetPoolDataResponse;
        }
    }
}