namespace Smartpool.Connection.Model
{
    public class RemoveMonitorUnitRequestMsg : TokenMsg
    {
        public RemoveMonitorUnitRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            MsgType = MessageTypes.RemoveMonitorUnitRequest;
        }
    }
}