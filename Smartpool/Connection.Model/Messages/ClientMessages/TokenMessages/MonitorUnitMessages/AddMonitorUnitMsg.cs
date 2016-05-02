namespace Smartpool.Connection.Model
{
    public class AddMonitorUnitRequestMsg : TokenMsg
    {
        public AddMonitorUnitRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            SubMsgType = TokenSubMessageTypes.AddMonitorUnitRequest;
        }
    }
}