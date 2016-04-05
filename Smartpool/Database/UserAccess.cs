namespace Smartpool
{
    public class UserAccess : IUserAccess
    {
        public bool AddUser(string name, string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public User FindUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}