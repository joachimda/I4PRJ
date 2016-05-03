using System.Collections.Generic;
using System.Linq;

namespace Smartpool
{
    public class PoolAccess : IPoolAccess
    { 
        public IUserAccess UserAccess { get; set; }

        public PoolAccess(IUserAccess userAccess)
        {
            UserAccess = userAccess;
        }
        /// <summary>
        /// Adds pool to a users poolSet.
        /// </summary
        /// <param name="email">The email of the user to recieve the pool</param>
        /// <param name="name">The pools name</param>
        /// <param name="volume">the pools volume</param>
        /// <returns>true on succes, false on fail</returns>
        public bool AddPool(string email, string name, double volume)
        {

            if (IsPoolNameAvailable(email, name) == false)
            {
                return false;
            }
            if (volume <= 0)
            {
                return false;
            }

            Pool newPool = new Pool { Name = name, User = UserAccess.FindUserByEmail(email), Volume = volume, UserId = UserAccess.FindUserByEmail(email).Id };

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
        /// <param name="email">The email of the user to run check against</param>
        /// <returns>True if name is available, false if name is in use</returns>
        public bool IsPoolNameAvailable(string email, string name)
        {
            using (var db = new DatabaseContext())
            {
                var searchPoolSet = from pool in db.PoolSet
                                    where pool.Name == name
                                    select pool;

                foreach (Pool pool in searchPoolSet)
                {
                    if (pool.UserId == UserAccess.FindUserByEmail(email).Id)
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
        /// <param name="email"> Email of the user to search upon for pools in</param>
        /// <param name="name">the name of the pool</param>
        /// <returns></returns>
        public Pool FindSpecificPool(string email, string name)
        {
            List<Pool> listOfFoundPools = new List<Pool>();

            if (IsPoolNameAvailable(email, name) == true)
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
        /// <param name="email">Identifies the administrating user</param>
        /// <param name="name">identifies the name of the pool</param>
        public bool RemovePool(string email, string name)
        {
            if (IsPoolNameAvailable(email, name))
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
                    if (pool.UserId == UserAccess.FindUserByEmail(email).Id)
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