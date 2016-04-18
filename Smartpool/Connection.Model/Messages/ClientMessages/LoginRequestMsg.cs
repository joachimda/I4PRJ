namespace Smartpool.Connection.Model
{
    public class LoginRequestMsg : ClientMsg
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginRequestMsg(string username, string password)
        {
            Username = username;
            Password = password;
            MsgType = MessageTypes.LoginRequest;
        }
    }
}