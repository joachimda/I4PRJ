using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        public bool AddData(string ownerEmail, string poolName)
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


        public List<Tuple<DateTime, Chlorine>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int howManyDaysToReturn)
        {
            using (var db = new DatabaseContext())
            {

                #region Query for all user specific chlorine data

                var chlorineDataQuery = from chlorineData in db.DataSet
                                        where chlorineData.Pool.User.Email == poolOwnerEmail
                                        select chlorineData;
                #endregion

                Tuple<TimestampInformation, Temperature> chlorineTuple = null;
                var queryStart = DateTime.Now.Day - howManyDaysToReturn;
                foreach (var data in chlorineDataQuery)
                {
                    if (data.Timestamp.Days >= queryStart)
                    {
                        chlorineTuple.Item1 = data.Timestamp;
                    }
                }

            }
            throw new NotImplementedException();
        }

        public List<Tuple<DateTime, Temperature>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int howManyDaysToReturn)
        {
            throw new NotImplementedException();
        }
    }
}