namespace Smartpool.Connection.Model
{
    public class ChangePasswordRequestMsg : TokenMsg
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordRequestMsg(string username, string tokenString, string oldPassword, string newPassword) : base(username, tokenString)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            SubMsgType = TokenSubMessageTypes.ChangePasswordRequest;
        }
    }
}