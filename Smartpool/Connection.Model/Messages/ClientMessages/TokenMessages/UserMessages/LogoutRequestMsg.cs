namespace Smartpool.Connection.Model
{
    public class LogoutMsg : TokenMsg
    {
        public LogoutMsg(string username, string tokenString) : base(username, tokenString)
        {
            MsgType = MessageTypes.LogoutRequest;
        }
    }
}