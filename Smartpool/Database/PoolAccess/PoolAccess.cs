using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Smartpool;

namespace Smartpool
{
    public class PoolAccess : IPoolAccess
    {
        /// <summary>
        /// Adds pool to a users poolSet.
        /// </summary
        /// <param name="user">The user to recieve the pool</param>
        /// <param name="name">The pools name</param>
        /// <param name="volume">the pools volume</param>
        /// <returns>true on succes, false on fail</returns>
        public bool AddPool(User user, string name, double volume)
        {
            if (IsPoolNameAvailable(user, name) == false)
            {
                return false;
            }
            if (volume <= 0)
            {
                return false;
            }

            Pool newPool = new Pool { Name = name, User = user, Volume = volume, UserId = user.Id };

            using (var db = new DatabaseContext())
            {
                db.PoolSet.Add(newPool);
                db.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Checks if a specific pool name is in use on a specific address
        /// </summary
        /// <param name="name">Name of the pool</param>
        /// <param name="user">The user to run check against</param>
        /// <returns>True if name is available, false if name is in use</returns>
        public bool IsPoolNameAvailable(User user, string name)
        {
            using (var db = new DatabaseContext())
            {
                var searchPoolSet = from pool in db.PoolSet
                                    where pool.Name == name
                                    select pool;

                foreach (Pool pool in searchPoolSet)
                {
                    if (pool.UserId == user.Id)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Finds a specific pool 
        /// </summary>
        /// <param name="user">Which user to search for pools in</param>
        /// <param name="name">the name of the pool</param>
        /// <returns></returns>
        public Pool FindSpecificPool(User user, string name)
        {
            List<Pool> listOfFoundPools = new List<Pool>();

            if (IsPoolNameAvailable(user, name) == true)
            {
                throw new PoolNotFoundException();
            }

            using (var db = new DatabaseContext())
            {
                var searchPools = from search in db.PoolSet
                                  where search.Name.Equals(name)
                                  select search;

                foreach (Pool pool in searchPools)
                {
                    listOfFoundPools.Add(pool);
                }
            }

            return listOfFoundPools[0];
        }

        /// <summary>
        /// Removes a specific pool
        /// </summary>
        /// <param name="user">Identifies the administrating user</param>
        /// <param name="name">identifies the name of the pool</param>
        public bool RemovePool(User userToFind, string name)
        {
            if (IsPoolNameAvailable(userToFind, name))
            {
                return false;
            }

            using (var db = new DatabaseContext())
            {
                var searchForPool = from pool in db.PoolSet
                                    where pool.Name == name
                                    select pool;

                foreach (Pool pool in searchForPool)
                {
                    if (pool.UserId == userToFind.Id)
                    {
                        db.PoolSet.Remove(pool);
                    }
                }

                db.SaveChanges();
            }

            return true;
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