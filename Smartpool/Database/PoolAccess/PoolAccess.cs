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
        /// <returns>true on succes, false on fail</returns>
        public bool AddPool(string userEmail, string name, double volume)
        {
 
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsPoolNameInUse(string userEmail, string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes a single pool from database
        /// </summary>
        /// <param name="email">Identifies the user</param>
        /// <param name="name">Identifies specific pool</param>
        /// <returns>true on succes, false on fail</returns>
        public bool RemovePool(string email, string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes all pools i database
        /// </summary>
        public void DeleteAllPools()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [PoolSet]");
            }
        }
    }
}