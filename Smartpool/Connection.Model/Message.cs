
namespace Smartpool.Connection.Model
{
    public enum MessageTypes
    {
        Login,
        Token,
        LoginResponse
    }
    public class Message
    {
        public string MessageInfo { get; set; }

        public Message()
        {
            
        }

        public Message(string messageInfo)
        {
            MessageInfo = messageInfo;
        }

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

    public class TokenMsg : ClientMsg
    {
        public string Username { get; set; }
        public string TokenString { get; set; }

        public TokenMsg(string username, string tokenString)
        {
            Username = username;
            TokenString = tokenString;
            MsgType = MessageTypes.Token;
        }
    }
    
    public class ServerMsg : Message
    {
        
    }

    public class LoginResponseMsg : ServerMsg
    {
        public string TokenString { get; set; }
        public bool LoginSuccessful { get; set; }

        public LoginResponseMsg(string tokenString, bool loginSuccessful)
        {
            TokenString = tokenString;
            LoginSuccessful = loginSuccessful;
            MsgType = MessageTypes.LoginResponse;
        }
    }

    public class TokenResponseMsg : ServerMsg
    {
        public bool TokenStillActive { get; set; }

        public TokenResponseMsg(bool tokenStillActive)
        {
            TokenStillActive = tokenStillActive;
        }
    }
}

