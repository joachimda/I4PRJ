using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Smartpool
{
    public class DataAccess : IDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        public DataAccess(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerEmail"></param>
        /// <param name="poolName"></param>
        /// <param name="chlorine"></param>
        /// <param name="temp"></param>
        /// <param name="pH"></param>
        /// <param name="humidity"></param>
        /// <returns></returns>
        public bool CreateDataEntry(string ownerEmail, string poolName, double chlorine, double temp, double pH, double humidity)
        {
            // make value checks here!

            if (PoolAccess.IsPoolNameAvailable(ownerEmail, poolName) == true) return false;

            using (var db = new DatabaseContext())
            {
                // find pool to add mesurements for
                int userId = PoolAccess.FindSpecificPool(ownerEmail, poolName).UserId;

                var poolsearch = from pools in db.PoolSet
                                 where pools.UserId == userId && pools.Name == poolName
                                 select pools;

                // check for errors in poolsearch
                if (poolsearch.Count() > 1) return false;
                if (poolsearch.Any() == false) return false;

                // create 'Data' entity to store measurements in
                string time = DateTime.UtcNow.ToString();
                var newData = new Data() { PoolId = poolsearch.First().Id, Timestamp = time };
                db.DataSet.Add(newData);
                db.SaveChanges();   // the newdata must be saved to db, so that mesurement can find it by PK

                // get latest dataset from db
                var datasearch = from data in db.DataSet
                                 where data.Timestamp == time
                                 select data;

                // check for errors in datasearch
                if (datasearch.Count() > 1) return false;
                if (datasearch.Any() == false) return false;

                // create measurements
                var newChlorine = new Chlorine() { DataId = datasearch.First().Id, Value = chlorine };
                var newTemperature = new Temperature() { DataId = datasearch.First().Id, Value = temp };
                var newPH = new pH() { DataId = datasearch.First().Id, Value = pH };
                var newHumidity = new Humidity() { DataId = datasearch.First().Id, Value = humidity };

                // add mesurements to db
                db.ChlorineSet.Add(newChlorine);
                db.TemperatureSet.Add(newTemperature);
                db.pHSet.Add(newPH);
                db.HumiditySet.Add(newHumidity);

                db.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerEmail"></param>
        /// <param name="poolName"></param>
        /// <returns></returns>
        public bool RemoveData(string ownerEmail, string poolName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Directly execute an SQL statemen on the database, deleting all DataSets
        /// </summary>
        /// <returns>Allways returning true</returns>
        public bool DeleteAllData()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [ChlorineSet]");
                db.Database.ExecuteSqlCommand("DELETE [pHSet]");
                db.Database.ExecuteSqlCommand("DELETE [TemperatureSet]");
                db.Database.ExecuteSqlCommand("DELETE [HumiditySet]");
                db.Database.ExecuteSqlCommand("DELETE [DataSet]");
            }

            return true;
        }

        /// <summary>
        /// Queries chlorine values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="start">Specifies the starting time of the query</param>
        /// <param name="end">Specifies the ending time of the query</param>
        /// <returns>A list of tuples, where each tuple contains a chlorine value and the hour where it was measured</returns>
        public List<Tuple<string, double>> GetChlorineValues(string poolOwnerEmail, string poolName, string start, string end)
        {
            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(end, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific chlorine data

                var chlorineDataQuery = from chlorine in db.ChlorineSet
                                        where chlorine.Data.Pool.Name == poolName && chlorine.Data.Pool.User.Email == poolOwnerEmail
                                        select chlorine;
                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<string, double>> chlorineTuples = new List<Tuple<string, double>>();

                foreach (var chlorine in chlorineDataQuery)
                {
                    if (DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture).CompareTo(startTime) > 0)
                    {
                        chlorineTuples.Add(new Tuple<string, double>(chlorine.Data.Timestamp, chlorine.Value));
                    }
                }

                #endregion

                return chlorineTuples;
            }
        }


        /// <summary>
        /// Queries chlorine values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="start">Specifies the starting time of the query</param>
        /// <param name="end">Specifies the ending time of the query</param>
        /// <returns>A list of tuples, where each tuple contains a chlorine value and the hour where it was measured</returns>
        public List<Tuple<string, double>> GetTemperatureValues(string poolOwnerEmail, string poolName, string start, string end)
        {
            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(end, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific temperature data

                var temperatureDataQuery = from temperature in db.TemperatureSet
                                           where temperature.Data.Pool.Name == poolName && temperature.Data.Pool.User.Email == poolOwnerEmail
                                           select temperature;

                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<string, double>> temperatureTuples = new List<Tuple<string, double>>();

                foreach (var temperature in temperatureDataQuery)
                {
                    if (DateTime.ParseExact(temperature.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(temperature.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture).CompareTo(startTime) > 0)
                    {
                        temperatureTuples.Add(new Tuple<string, double>(temperature.Data.Timestamp, temperature.Value));
                    }
                }

                #endregion

                return temperatureTuples;
            }
        }

        public List<Tuple<string, double>> GetPhValues(string poolOwnerEmail, string poolName, string start, string end)
        {
            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(end, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific pH data

                var phDataQuery = from ph in db.pHSet
                                           where ph.Data.Pool.Name == poolName && ph.Data.Pool.User.Email == poolOwnerEmail
                                           select ph;

                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<string, double>> temperatureTuples = new List<Tuple<string, double>>();

                foreach (var ph in phDataQuery)
                {
                    if (DateTime.ParseExact(ph.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(ph.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture).CompareTo(startTime) > 0)
                    {
                        temperatureTuples.Add(new Tuple<string, double>(ph.Data.Timestamp, ph.Value));
                    }
                }

                #endregion
            }
        }

        public List<Tuple<string, double>> GetHumidityValues(string poolOwnerEmail, string poolName, string start, string end)
        {
            throw new NotImplementedException();
        }
    }
}