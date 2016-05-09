using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        public DataAccess(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
        }

        public bool AddData(string ownerEmail, string poolName)
        {
            if (PoolAccess.UserAccess.IsEmailInUse(ownerEmail) == false) return false;
            if (PoolAccess.IsPoolNameAvailable(ownerEmail, poolName) == true) return false;

            Data data = new Data() { PoolId = PoolAccess.FindSpecificPool(ownerEmail, poolName).Id };

            using (var db = new DatabaseContext())
            {
                db.DataSet.Add(data);
                db.SaveChanges();
            }

            return true;
        }

        public bool RemoveData(string ownerEmail, string poolName)
        {
            return false;
        }

        public bool DeleteAllData()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [DataSet]");
            }

            return true;
        }

        public bool CreateChlorineEntry(string poolOwnerEmail, string poolName, int chlorineValue)
        {
            if (!PoolAccess.UserAccess.IsEmailInUse(poolOwnerEmail))
            {
                return false;
            }
            Chlorine chlorine = new Chlorine { Value = chlorineValue };

            using (var db = new DatabaseContext())
            {
                db.ChlorineSet.Add(chlorine);
            }
            throw new NotImplementedException();
        }

        public bool CreateTemperatureEntry(string poolOwnerEmail, string poolName, int temperatureValue)
        {
            throw new NotImplementedException();
        }


        public List<Tuple<int, Chlorine>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int queryStartDay)
        {
            using (var db = new DatabaseContext())
            {

                #region Query for all user specific data

                var chlorineDataQuery = from userSpecificData in db.DataSet
                                        where userSpecificData.Pool.User.Email == poolOwnerEmail &&  userSpecificData.Pool.Name == poolName
                                        select userSpecificData;
                #endregion


                List <Tuple<DateTime, Chlorine> > ChlorineTuples = null;

                foreach (var data in chlorineDataQuery)
                {
                    if (data.Timestamp >= queryStartDay)
                    {

                    }
                }

            }
            throw new NotImplementedException();
        }

        public List<Tuple<int, Temperature>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int queryStartDay)
        {
            throw new NotImplementedException();
        }

    }

    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 item, T2 item2)
        {
            Add(new Tuple<T1, T2>(item, item2));
        }
    }
}