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

        public bool AddData(string ownerEmail, string poolName, double chlorine, double temp, double ph, double humidity)
        {
            if (PoolAccess.UserAccess.IsEmailInUse(ownerEmail) == false) return false;
            if (PoolAccess.IsPoolNameAvailable(ownerEmail, poolName) == true) return false;

            //Chlorine chlorine = new Chlorine() {DataId = };

            Data data = new Data() { PoolId = PoolAccess.FindSpecificPool(ownerEmail, poolName).Id};

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

        public List<Tuple<int, Chlorine>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int queryStartDay)
        {
            using (var db = new DatabaseContext())
            {

                #region Query for all user specific data

                var chlorineDataQuery = from userSpecificData in db.DataSet
                                        where userSpecificData.Pool.User.Email == poolOwnerEmail && userSpecificData.Pool.Name == poolName
                                        select userSpecificData;
                #endregion


                var daysToGoBack = -queryStartDay;

                List<Tuple<DateTime, Chlorine>> ChlorineTuples = null;

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