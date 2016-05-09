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


        public List<Tuple<long, double>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, long queryStartHour)
        {
            using (var db = new DatabaseContext())
            {
                #region Check for invalid starting hour

                if (queryStartHour < 0)
                {
                    throw new ArgumentException("Invalid start hour, stupid!");
                }

                #endregion

                #region Query for all user-pool specific chlorine data

                var chlorineDataQuery = from chlorine in db.ChlorineSet
                                        where chlorine.Data.Pool.Name == poolName && chlorine.Data.Pool.User.Email == poolOwnerEmail
                                        select chlorine;
                #endregion

                #region Add date-relevant chlorine date to Tuple list
                List<Tuple<long, double>> chlorineTuples = null;

                foreach (var dataEntity in chlorineDataQuery)
                {
                    if (dataEntity.Data.Timestamp > queryStartHour)
                    {
                        chlorineTuples.Add(new Tuple<long, double>(dataEntity.Data.Timestamp, dataEntity.Value));
                    }
                }
                #endregion

                return chlorineTuples;
            }
        }

        public List<Tuple<long, double>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, long queryStartHour)
        {
            throw new NotImplementedException();
        }

    }

}