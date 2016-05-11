namespace Smartpool.Connection.Model
{
    public class RemovePoolRequestMsg : TokenMsg
    {
        public string PoolName { get; set; }

        public RemovePoolRequestMsg(string username, string tokenString, string poolName) : base(username, tokenString)
        {
            PoolName = poolName;
            SubMsgType = TokenSubMessageTypes.RemovePoolRequest;
        }
    }
}