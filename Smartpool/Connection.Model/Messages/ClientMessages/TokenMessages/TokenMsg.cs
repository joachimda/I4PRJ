namespace Smartpool.Connection.Model
{
    public class TokenMsg : ClientMsg
    {
        public string Username { get; set; }
        public string TokenString { get; set; }
        public TokenMsg() { }

        public TokenMsg(string username, string tokenString)
        {
            Username = username;
            TokenString = tokenString;
            MsgType = MessageTypes.Token;
        }
    }

    public class AddPoolMsg : TokenMsg
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }

        public AddPoolMsg(string username, string tokenString, string poolAddress, string poolName, double poolVolume)
        {
            Username = username;
            TokenString = tokenString;
            Address = poolAddress;
            Name = poolName;
            Volume = poolVolume;
            MsgType = MessageTypes.AddPool;
        }
    }
}