namespace Smartpool.Connection.Model
{
    public class AddUserResponseMsg : ServerMsg
    {
        public bool UserAdded { get; set; }

        public AddUserResponseMsg(bool userAdded)
        {
            UserAdded = userAdded;
        }
    }
}
