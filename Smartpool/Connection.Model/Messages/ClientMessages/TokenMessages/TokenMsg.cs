namespace Smartpool.Connection.Model
{
    public class TokenMsg : ClientMsg
    {
        public string Username { get; set; }
        public string TokenString { get; set; }
        
        protected TokenMsg(string username, string tokenString)
        {
            Username = username;
            TokenString = tokenString;
            MsgType = MessageTypes.TokenMsg;
        }
    }
}