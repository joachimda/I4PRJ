using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        public bool AddData(string ownerEmail, string poolName)
        {
            if (PoolAccess.UserAccess.IsEmailInUse(ownerEmail) == false) return false;
            if (PoolAccess.IsPoolNameAvailable(ownerEmail, poolName) == true) return false;

            Data data = new Data();

            using (var db = new DatabaseContext())
            {
                db.DataSet.Add(data);
                db.SaveChanges();
            }

            return true;
        }

        public bool RemoveData(string ownerEmail, string poolName)
        {

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

        public Dictionary<DateTime, Temperature> GetRecentChlorineValues(string poolOwnerEmail, string poolName, int howManyToReturns)
        {
            throw new NotImplementedException();
        }

        public Dictionary<DateTime, Temperature> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, int howManyToReturns)
        {
            throw new NotImplementedException();
        }
    }
}