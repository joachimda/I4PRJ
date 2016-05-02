namespace Smartpool.Connection.Model
{
    public class RemovePoolRequestMsg : TokenMsg
    {
        public string Address { get; set; }
        public string PoolName { get; set; }

        public RemovePoolRequestMsg(string username, string tokenString, string address, string poolName) : base(username, tokenString)
        {
            Address = address;
            PoolName = poolName;
            SubMsgType = TokenSubMessageTypes.RemovePoolRequest;
        }
    }
}