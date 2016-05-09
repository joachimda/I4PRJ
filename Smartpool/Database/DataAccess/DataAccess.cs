using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        public DataAccess(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
        }
        
        public bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveData(string ownerEmail, string poolName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAllData()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [DataSet]");
            }

            return true;
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