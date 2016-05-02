namespace Smartpool.Connection.Model
{
    public class UpdatePoolRequestMsg : TokenMsg
    {
        public string OldPoolName { get; set; }
        public string NewPoolAddress { get; set; }
        public string NewPoolName { get; set; }
        public double NewPoolVolume { get; set; }

        public UpdatePoolRequestMsg(string username, string tokenString, string oldPoolName, string newPoolAddress, string newPoolName, double newPoolVolume) : base(username, tokenString)
        {
            OldPoolName = oldPoolName;
            NewPoolAddress = newPoolAddress;
            NewPoolName = newPoolName;
            NewPoolVolume = newPoolVolume;
            SubMsgType = TokenSubMessageTypes.UpdatePoolRequest;
        }
    }
}