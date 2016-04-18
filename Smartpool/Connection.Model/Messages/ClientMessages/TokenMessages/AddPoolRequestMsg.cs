namespace Smartpool.Connection.Model
{
    public class AddPoolRequestMsg : TokenRequestMsg
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }

        public AddPoolRequestMsg(string username, string tokenString, string poolAddress, string poolName, double poolVolume)
        {
            Username = username;
            TokenString = tokenString;
            Address = poolAddress;
            Name = poolName;
            Volume = poolVolume;
            MsgType = MessageTypes.AddPoolRequest;
        }
    }
}