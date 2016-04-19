namespace Smartpool.Connection.Model
{
    public class ResetPasswordRequestMsg : ClientMsg
    {
        public string Username { get; set; }

        public ResetPasswordRequestMsg(string username)
        {
            Username = username;
            MsgType = MessageTypes.ResetPasswordRequest;
        }
    }
}