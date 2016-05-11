namespace Smartpool.Connection.Model
{
    public class GetPoolDataRequestMsg : TokenMsg
    {
        public bool GetAllNamesOnly { get; set; }
        public string PoolName { get; set; }
        public int GetHistoryDays { get; set; }

        public GetPoolDataRequestMsg(string username, string tokenString, bool getAllNamesOnly = false, string poolName = "", int getHistoryDays = 0)
            : base(username, tokenString)
        {
            GetAllNamesOnly = getAllNamesOnly;
            PoolName = poolName;
            GetHistoryDays = getHistoryDays;
            SubMsgType = TokenSubMessageTypes.GetPoolDataRequest;
        }
    }
}