namespace Smartpool.Connection.Model
{
    public class UpdateMonitorUnitRequestMsg : TokenMsg
    {
        public UpdateMonitorUnitRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            SubMsgType = TokenSubMessageTypes.UpdateMonitorUnitRequest;
        }
    }
}