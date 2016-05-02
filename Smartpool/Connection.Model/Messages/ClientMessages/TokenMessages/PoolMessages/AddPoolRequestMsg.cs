namespace Smartpool.Connection.Model
{
    public class AddPoolRequestMsg : TokenMsg
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public AddPoolRequestMsg(string username, string tokenString, string poolName, double poolVolume) : base(username, tokenString)
        {
            Name = poolName;
            Volume = poolVolume;
            SubMsgType = TokenSubMessageTypes.AddPoolRequest;
        }
    }
}