namespace Smartpool.Connection.Model
{
    public class AddUserMsg : ClientMsg
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AddUserMsg(string fullname, string username, string password)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            MsgType = MessageTypes.AddUser;
        }
    }
}