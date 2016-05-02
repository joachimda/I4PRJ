namespace Smartpool.Connection.Model
{
    public class LogoutRequestMsg : TokenMsg
    {
        public LogoutRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            SubMsgType = TokenSubMessageTypes.LogoutRequest;
        }
    }
}