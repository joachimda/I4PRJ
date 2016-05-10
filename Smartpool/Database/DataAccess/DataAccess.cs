﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartpool.DataAccess
{
    public class DataAccess : IWriteDataAccess, IReadDataAccess
    {
        public IPoolAccess PoolAccess { get; set; }

        /// <summary>
        /// Constructor - dataaccess setup
        /// </summary>
        /// <param name="poolAccess">Initializes an IPoolAcces member</param>
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
                var poolsearch = from pools in db.PoolSet
                                 where pools.UserId == PoolAccess.FindSpecificPool(ownerEmail, poolName).Id && pools.Name == poolName
                                 select pools;

                // check for errors in poolsearch
                if (poolsearch.Count() > 1) return false;
                if (poolsearch.Any() == false) return false;

                // create 'Data' entity to store measurements in
                var newData = new Data() {PoolId = poolsearch.First().Id/*, Timestamp = int.Parse(DateTime.Now)*/ };

                // create measurements
                var newChlorine = new Chlorine() { DataId = poolsearch.First().Id, Value = chlorine };
                var newTemperature = new Temperature() { DataId = poolsearch.First().Id, Value = temp };
                var newPH = new pH() { DataId = poolsearch.First().Id, Value = pH };
                var newHumidity = new Humidity() { DataId = poolsearch.First().Id, Value = humidity };

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
                db.Database.ExecuteSqlCommand("DELETE [DataSet]");
            }

            return true;
        }

        /// <summary>
        /// Queries chlorine values within a given hour range
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="queryStartHour">Specifies how many hours to look back in time</param>
        /// <returns>A list of tuples, where each tuple contains a chlorine value and the hour where it was measured</returns>
        public List<Tuple<long, double>> GetRecentChlorineValues(string poolOwnerEmail, string poolName, long queryStartHour)
        {
            using (var db = new DatabaseContext())
            {
                #region Check for invalid starting hour

                if (queryStartHour < 0)
                {
                    throw new ArgumentException("Invalid starting hour from ChlorineQuery, stupid!");
                }

                #endregion

                #region Query for all user-pool specific chlorine data

                var chlorineDataQuery = from chlorine in db.ChlorineSet
                                        where chlorine.Data.Pool.Name == poolName && chlorine.Data.Pool.User.Email == poolOwnerEmail
                                        select chlorine;
                #endregion

                #region Add date-relevant chlorine data to Tuple list
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

        /// <summary>
        /// Queries temperatures within a given hour range
        /// </summary>
        /// <param name="poolOwnerEmail">The email of the pool owner</param>
        /// <param name="poolName">The specific pool name</param>
        /// <param name="queryStartHour">Specifies how many hours to look back in time</param>
        /// <returns>A list of tuples, where each tuple contains a temperature value and the hour where it was measured</returns>
        public List<Tuple<long, double>> GetRecentTemperatureValues(string poolOwnerEmail, string poolName, long queryStartHour)
        {
            using (var db = new DatabaseContext())
            {
                #region Check for invalid starting hour

                if (queryStartHour < 0)
                {
                    throw new ArgumentException("Invalid starting hour from TemperatureQuery, stupid!");
                }

                #endregion

                #region Query for all user-pool specific temperature data

                var temperatureDataQuery = from temperature in db.TemperatureSet
                                           where temperature.Data.Pool.Name == poolName && temperature.Data.Pool.User.Email == poolOwnerEmail
                                           select temperature;
                #endregion

                #region Add date-relevant temperature data to Tuple list

                List<Tuple<long, double>> temperatureTuples = null;

                foreach (var dataEntity in temperatureDataQuery)
                {
                    if (dataEntity.Data.Timestamp > queryStartHour)
                    {
                        temperatureTuples.Add(new Tuple<long, double>(dataEntity.Data.Timestamp, dataEntity.Value));
                    }
                }
                #endregion

                return temperatureTuples;
            }
        }
    }
}