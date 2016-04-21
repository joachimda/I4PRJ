namespace Smartpool.Connection.Model
{
    public class GetMonitorUnitRequestMsg : TokenMsg
    {
        public GetMonitorUnitRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            MsgType = MessageTypes.GetMonitorUnitRequest;
        }
    }
}