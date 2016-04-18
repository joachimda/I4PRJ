namespace Smartpool.Connection.Model
{
    public class TokenRequestMsg : ClientMsg
    {
        public string Username { get; set; }
        public string TokenString { get; set; }
        
        public TokenRequestMsg()
        {
            MsgType = MessageTypes.TokenRequest;
        }
    }
}