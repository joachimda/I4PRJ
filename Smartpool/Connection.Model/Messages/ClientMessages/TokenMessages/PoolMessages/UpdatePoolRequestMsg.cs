namespace Smartpool.Connection.Model
{
    public class UpdatePoolRequestMsg : TokenMsg
    {
        public string OldPoolName { get; set; }
        public string NewPoolName { get; set; }
        public double NewPoolVolume { get; set; }

        public UpdatePoolRequestMsg(string username, string tokenString, string oldPoolName, string newPoolName = "", double newPoolVolume = 0) : base(username, tokenString)
        {
            OldPoolName = oldPoolName;
            NewPoolName = newPoolName;
            NewPoolVolume = newPoolVolume;
            SubMsgType = TokenSubMessageTypes.UpdatePoolRequest;
        }
    }
}