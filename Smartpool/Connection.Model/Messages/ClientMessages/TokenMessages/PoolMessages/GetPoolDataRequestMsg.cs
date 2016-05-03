namespace Smartpool.Connection.Model
{
    public class GetPoolDataRequestMsg : TokenMsg
    {
        public bool GetAllNamesOnly { get; set; }
        public int GetHistoryDays { get; set; }

        public GetPoolDataRequestMsg(string username, string tokenString) : base(username, tokenString)
        {
            SubMsgType = TokenSubMessageTypes.GetPoolDataRequest;
        }

        public GetPoolDataRequestMsg(string username, string tokenString, bool getAllNamesOnly = false, int getHistoryDays = 0)
            : base(username, tokenString)
        {
            GetAllNamesOnly = getAllNamesOnly;
            GetHistoryDays = getHistoryDays;
            SubMsgType = TokenSubMessageTypes.GetPoolDataRequest;
        }
    }
}