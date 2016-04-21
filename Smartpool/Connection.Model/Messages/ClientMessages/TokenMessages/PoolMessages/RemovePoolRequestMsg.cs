namespace Smartpool.Connection.Model
{
    public class RemovePoolMsg : TokenMsg
    {
        public string Address { get; set; }
        public string PoolName { get; set; }

        public RemovePoolMsg(string username, string tokenString, string address, string poolName) : base(username, tokenString)
        {
            Address = address;
            PoolName = poolName;
            MsgType = MessageTypes.RemovePoolRequest;
        }
    }
}