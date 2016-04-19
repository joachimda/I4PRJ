namespace Smartpool.Connection.Model
{
    public class LoginResponseMsg : Message
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
}