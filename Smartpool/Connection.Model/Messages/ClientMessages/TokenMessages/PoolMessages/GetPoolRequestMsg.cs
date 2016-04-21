namespace Smartpool.Connection.Model
{
    public class GetPoolRequestMsg : TokenMsg
    {
        public GetPoolRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            MsgType = MessageTypes.GetPoolRequest;
        }
    }
}