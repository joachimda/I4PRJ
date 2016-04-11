namespace Smartpool.Factories
{
    public class PoolAccess : IPoolAccess
    {
        public bool AddUser(string fullname, string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public User FindUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmailInUse(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidatePassword(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}