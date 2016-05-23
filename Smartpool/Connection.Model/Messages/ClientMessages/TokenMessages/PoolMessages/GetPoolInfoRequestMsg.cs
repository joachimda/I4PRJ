namespace Smartpool.Connection.Model
{
    public class GetPoolInfoRequestMsg : TokenMsg
    {
        public string PoolName { get; set; }

        public GetPoolInfoRequestMsg(string username, string tokenString, string poolName) : base(username, tokenString)
        {
            PoolName = poolName;
            SubMsgType = TokenSubMessageTypes.GetPoolInfoRequest;
        }
    }
}