using System.Collections.Generic;

namespace Smartpool.Factories
{
    public class PoolAccess : IPoolAccess
    {
        /// <summary>
        /// Adds pool to a users poolSet
        /// </summary>
        /// <param name="email">Identifying the 'owner' of the pool</param>
        /// <param name="name">The pools name</param>
        /// <param name="volume">the pools volume</param>
        /// <param name="address">the address of the pool location</param>
        /// <returns>true on succes, false on fail</returns>
        public bool AddPool(string email, string address, string name, double volume)
        {
 
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checks if a specific pool name is in use on a specific address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address">the address of the pool location</param>
        /// <returns></returns>
        public bool IsPoolNameInUse(string email, string address, string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Finds all pools 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="address">the address of the pool location</param>
        /// <param name="name">the name of the pool</param>
        /// <returns></returns>
        public Pool FindSpecificPool(string email, string address, string name)
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