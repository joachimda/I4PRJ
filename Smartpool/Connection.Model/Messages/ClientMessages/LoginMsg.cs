namespace Smartpool.Connection.Model
{
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
}