namespace Smartpool.Connection.Model
{
    public enum MessageTypes
    {
        Login,
        GetInfo,
        GetPoolInfo
    }
    public class Message
    {
        public MessageTypes MsgType { get; set; }
    }

    public class ClientMsg : Message
    {
        
    }

    public class LoginMsg : ClientMsg
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginMsg(string username, string password)
        {
            Username = username;
            Password = password;
            MsgType = MessageTypes.Login;
        }
    }


    public class ServerMsg : Message
    {
        
    }

    public class LoginResponseMsg : ServerMsg
    {
        
    }
}

