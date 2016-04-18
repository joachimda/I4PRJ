namespace Smartpool.Connection.Model
{
    public class AddUserRequestMsg : ClientMsg
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AddUserRequestMsg(string fullname, string username, string password)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            MsgType = MessageTypes.AddUserRequest;
        }
    }
}