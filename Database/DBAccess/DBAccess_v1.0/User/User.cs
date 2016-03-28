using System.Collections.Generic;

namespace DBAccessV1
{
    public class User
    {
        #region Properties

        public string Firstname { get; }
        public string Middelname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public string Password { get; }

        public List<IPoolWrite> PoolsOwned { get; set; } // list for personal pools
        public List<IPoolRead> PoolsViewed { get; set; } // list for spectating pools

        #endregion
        
        #region Constructors

        public User(string firstname, string lastname, string email, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        public User(string firstname, string middelname, string lastname, string email, string password)
        {
            Firstname = firstname;
            Middelname = middelname;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        #endregion

        #region AddPool Method

        public void AddPool(IPoolRead pool)
        {
            PoolsViewed.Add(pool);
        }

        public void AddPool(IPoolWrite pool)
        {
            PoolsOwned.Add(pool);
        }

        #endregion
    }
}