using System.Linq;
using Smartpool;

namespace Smartpool
{
    public class PoolAccess : IPoolAccess
    {
        /// <summary>
        /// Adds pool to a users poolSet.
        /// </summary
        /// <param name="name">The pools name</param>
        /// <param name="volume">the pools volume</param>
        /// <param name="user">The user to recieve the pool</param>
        /// <param name="address">the address of the pool location</param>
        /// <returns>true on succes, false on fail</returns>
        public void AddPool(User user, string address, string name, double volume)
        {
            Pool newPool = new Pool { Address = address, Name = name, User = user, Volume = volume, UserId = user.Id };
            user.Pool.Add(newPool);
        }

        /// <summary>
        /// Checks if a specific pool name is in use on a specific address
        /// </summary
        /// <param name="name">Name of the pool</param>
        /// <param name="user">The user to run check against</param>
        /// <param name="address">the address of the pool location</param>
        /// <returns>True if name is in use, false if name is availible</returns>
        public bool IsPoolNameInUse(User user, string address, string name)
        {
            foreach (var pool in user.Pool)
            {
                return pool.Address == address && pool.Name == name;
            }

            return false;
        }

        /// <summary>
        /// Finds a specific pool 
        /// </summary>
        /// <param name="user">Which user to search for pools in</param>
        /// <param name="address">the address of the pool location</param>
        /// <param name="name">the name of the pool</param>
        /// <returns></returns>
        public Pool FindSpecificPool(User user, string address, string name)
        {
            Pool tmpPool = null;
            foreach (var pool in user.Pool)
            {
                if (pool.Name == name)
                {
                    tmpPool = pool;
                }
            }
            return tmpPool;
        }

        /// <summary>
        /// Removes a specific pool
        /// </summary>
        /// <param name="user">Identifies the administrating user</param>
        /// <param name="address"> identifies the pool address</param>
        /// <param name="name">identifies the name of the pool</param>
        public void RemovePool(User user, string address, string name)
        {
            using (var db = new DatabaseContext())
            {
                if (!IsPoolNameInUse(user, address, name))
                {
                    throw new PoolNotFoundException();
                }

                foreach (var pool in user.Pool)
                {
                    if (pool.Name == name)
                    {
                        db.PoolSet.Remove(pool);
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Removes all pools i database
        /// </summary>
        public
        void DeleteAllPools()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [PoolSet]");
            }
        }
    }
}