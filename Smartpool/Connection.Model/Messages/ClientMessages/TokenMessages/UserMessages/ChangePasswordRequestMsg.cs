namespace Smartpool.Connection.Model
{
    public class ChangePasswordMsg : TokenMsg
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordMsg(string username, string tokenString, string oldPassword, string newPassword) : base(username, tokenString)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            MsgType = MessageTypes.ChangePasswordRequest;
        }
    }
}