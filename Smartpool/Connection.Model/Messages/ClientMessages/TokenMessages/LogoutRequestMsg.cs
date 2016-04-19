namespace Smartpool.Connection.Model
{
    public class LogoutRequestMsg : TokenRequestMsg
    {
        public LogoutRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            MsgType = MessageTypes.LogoutRequest;
        }
    }
}