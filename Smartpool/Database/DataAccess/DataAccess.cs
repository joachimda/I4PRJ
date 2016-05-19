using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Smartpool.Connection.Model;

namespace Smartpool
{
    public class DataAccess : IDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="poolAccess">Sets the pool access datamember</param>
        public DataAccess(IPoolAccess poolAccess)
        {
            PoolAccess = poolAccess;
        }

        /// <summary>
        /// Creates a data entry with all types of data
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
        /// Directly execute an SQL statemen on the database, deleting all DataSets
        /// </summary>
        /// <returns>Allways returning true</returns>
        public void DeleteAllData()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [ChlorineSet]");
                db.Database.ExecuteSqlCommand("DELETE [pHSet]");
                db.Database.ExecuteSqlCommand("DELETE [TemperatureSet]");
                db.Database.ExecuteSqlCommand("DELETE [HumiditySet]");
                db.Database.ExecuteSqlCommand("DELETE [DataSet]");
            }
        }

        /// <summary>
        /// Queries chlorine values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="daysToGoBack">Specifies how many days ago to start looking at data</param>
        /// <returns>A list of tuples, where each tuple contains a chlorine value and the sensor that measured it</returns>
        public List<Tuple<SensorTypes, double>> GetChlorineValues(string poolOwnerEmail, string poolName, int daysToGoBack)
        {
            double days = System.Convert.ToDouble(daysToGoBack);
            string now = DateTime.UtcNow.ToString("G");
            string start = DateTime.Parse(now).AddDays(-days).ToString("G");

            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(now, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific chlorine data

                var chlorineDataQuery = from chlorine in db.ChlorineSet
                                        where chlorine.Data.Pool.Name == poolName && chlorine.Data.Pool.User.Email == poolOwnerEmail
                                        select chlorine;
                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<SensorTypes, double>> chlorineTuples = new List<Tuple<SensorTypes, double>>();

                //foreach (var chlorine in chlorineDataQuery)
                //{
                //    if (DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                //        System.Globalization.CultureInfo.InvariantCulture).CompareTo(endTime) < 0 ||
                //        DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss",
                //            System.Globalization.CultureInfo.InvariantCulture).CompareTo(startTime) > 0)
                //    {
                //        chlorineTuples.Add(new Tuple<SensorTypes, double>(SensorTypes.Chlorine, chlorine.Value));
                //    }
                //}

                foreach (var chlorine in chlorineDataQuery)
                {
                    if (DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(chlorine.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(startTime) > 0)
                    {
                        chlorineTuples.Add(new Tuple<SensorTypes, double>(SensorTypes.Chlorine, chlorine.Value));
                    }
                }

                #endregion

                return chlorineTuples;
            }
        }

        /// <summary>
        /// Queries temperature values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="daysToGoBack">Specifies how many days ago to start looking at data</param>
        /// <returns>A list of tuples, where each tuple contains a temperature value and the sensor that measured it</returns>
        public List<Tuple<SensorTypes, double>> GetTemperatureValues(string poolOwnerEmail, string poolName, int daysToGoBack)
        {
            double days = System.Convert.ToDouble(daysToGoBack);
            string now = DateTime.UtcNow.ToString("G");
            string start = DateTime.Parse(now).AddDays(-days).ToString("G");

            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(now, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific temperature data

                var temperatureDataQuery = from temperature in db.TemperatureSet
                                           where temperature.Data.Pool.Name == poolName && temperature.Data.Pool.User.Email == poolOwnerEmail
                                           select temperature;

                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<SensorTypes, double>> temperatureTuples = new List<Tuple<SensorTypes, double>>();

                foreach (var temperature in temperatureDataQuery)
                {
                    if (DateTime.ParseExact(temperature.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(temperature.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(startTime) > 0)
                    {
                        temperatureTuples.Add(new Tuple<SensorTypes, double>(SensorTypes.Temperature, temperature.Value));
                    }
                }

                #endregion

                return temperatureTuples;
            }
        }

        /// <summary>
        /// Queries pH values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owne</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="daysToGoBack">Specifies how many days ago to start looking at data</param>
        /// <returns>A list of tuples, where each tuple contains a pH value and the sensor that measured it</returns>
        public List<Tuple<SensorTypes, double>> GetPhValues(string poolOwnerEmail, string poolName, int daysToGoBack)
        {

            double days = System.Convert.ToDouble(daysToGoBack);
            string now = DateTime.UtcNow.ToString("G");
            string start = DateTime.Parse(now).AddDays(-days).ToString("G");

            using (var db = new DatabaseContext())

            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(now, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific pH data

                var phDataQuery = from ph in db.pHSet
                                  where ph.Data.Pool.Name == poolName && ph.Data.Pool.User.Email == poolOwnerEmail
                                  select ph;

                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<SensorTypes, double>> phTuples = new List<Tuple<SensorTypes, double>>();

                foreach (var ph in phDataQuery)
                {
                    if (DateTime.ParseExact(ph.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(endTime) < 0 ||
                        DateTime.ParseExact(ph.Data.Timestamp, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-GB")).CompareTo(startTime) > 0)
                    {
                        phTuples.Add(new Tuple<SensorTypes, double>(SensorTypes.Ph, ph.Value));
                    }
                }

                #endregion

                return phTuples;
            }
        }

        /// <summary>
        /// Queries humidity values within a given time range: dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owne</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="daysToGoBack">Specifies how many days ago to start looking at data</param>
        /// <returns>A list of tuples, where each tuple contains a humidity value and the sensor that measured it</returns>
        public List<Tuple<SensorTypes, double>> GetHumidityValues(string poolOwnerEmail, string poolName, int daysToGoBack)
        {

            double days = System.Convert.ToDouble(daysToGoBack);
            string now = DateTime.UtcNow.ToString("G");
            string start = DateTime.Parse(now).AddDays(-days).ToString("G");

            using (var db = new DatabaseContext())
            {
                #region Convert start and end times to DateTime types

                DateTime startTime = DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                DateTime endTime = DateTime.ParseExact(now, "dd/MM/yyyy HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);

                #endregion

                #region Query for all user-pool specific humidity data

                var humidityDataQuery = from humidity in db.HumiditySet
                                        where humidity.Data.Pool.Name == poolName && humidity.Data.Pool.User.Email == poolOwnerEmail
                                        select humidity;

                #endregion

                #region Check for timestamp matches and add to tuples

                List<Tuple<SensorTypes, double>> humidityTuples = new List<Tuple<SensorTypes, double>>();

                foreach (var humidity in humidityDataQuery)
                {
                    if (DateTime.Parse(humidity.Data.Timestamp).CompareTo(endTime) < 0 ||
                        DateTime.Parse(humidity.Data.Timestamp).CompareTo(startTime) > 0)
                    {
                        humidityTuples.Add(new Tuple<SensorTypes, double>(SensorTypes.Humidity, humidity.Value));
                    }
                }

                #endregion

                return humidityTuples;
            }
        }
    }
}