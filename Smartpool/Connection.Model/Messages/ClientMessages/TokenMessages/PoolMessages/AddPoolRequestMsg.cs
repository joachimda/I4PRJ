namespace Smartpool.Connection.Model
{
    public class AddPoolMsg : TokenMsg
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public AddPoolMsg(string username, string tokenString, string poolName, double poolVolume) : base(username, tokenString)
        {
            Name = poolName;
            Volume = poolVolume;
            MsgType = MessageTypes.AddPoolRequest;
        }
    }
}