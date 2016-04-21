namespace Smartpool.Connection.Model
{
    public class AddPoolMsg : TokenMsg
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }

        public AddPoolMsg(string username, string tokenString, string poolAddress, string poolName, double poolVolume) : base(username, tokenString)
        {
            Address = poolAddress;
            Name = poolName;
            Volume = poolVolume;
            MsgType = MessageTypes.AddPoolRequest;
        }
    }
}