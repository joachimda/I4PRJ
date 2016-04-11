namespace Smartpool.Connection.Model
{
    public class Message
    {
        public int Id { get; }
        public string MsgType { get; set; }
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
        }
    }


    public class ServerMsg : Message
    {
        
    }

    public class LoginResponseMsg : ServerMsg
    {
        
    }
}

