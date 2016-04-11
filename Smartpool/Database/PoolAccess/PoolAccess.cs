namespace Smartpool.Factories
{
    public class PoolAccess : IPoolAccess
    {
        /// <summary>
        /// Adds pool to a users poolSet
        /// </summary>
        /// <param name="userEmail">Identifying the 'owner' of the pool</param>
        /// <param name="name">The pools name</param>
        /// <param name="volume">the pools volume</param>
        /// <returns></returns>
        public bool AddPool(string userEmail, string name, double volume)
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