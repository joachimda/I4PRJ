using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Smartpool;
using Smartpool.Connection.Model;

namespace Database.Test.Unit
{
    [TestFixture]
    public class DataAccessUnitTest
    {
        #region Setup

        private IDataAccess _uut;
        private IUserAccess _userAccess;
        private IPoolAccess _poolAccess;

        string ownerEmail, poolName;
        private int poolId;

        [SetUp]
        public void Setup()
        {
            poolName = "baghave";
            ownerEmail = "hansen@gmail.com";

            _userAccess = new UserAccess();
            _poolAccess = new PoolAccess(_userAccess);
            _uut = new DataAccess(_poolAccess);

            _userAccess.AddUser("Sir Derp Hansen", ownerEmail, "hanpassword");
            _poolAccess.AddPool(ownerEmail, poolName, 8);
            poolId = _poolAccess.FindSpecificPool(ownerEmail, poolName).Id;
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllData();
            _poolAccess.DeleteAllPools();
            _userAccess.DeleteAllUsers();
        }

        #endregion

        #region CreateDataEntry

        [Test]
        public void CreateDataEntry_AddingDataToNonExistingPoolAndUser_ReturnsFalse()
        {
            Assert.That(_uut.CreateDataEntry("invalid", "invalid", 987, 89, 8, 33), Is.False);
        }

        [Test]
        public void CreateDataEntry_AddingDataToNonExistingPool_ReturnsFalse()
        {
            Assert.That(_uut.CreateDataEntry(ownerEmail, "invalid", 987, 89, 8, 33), Is.False);
        }

        [Test]
        public void CreateDataEntry_AddingDataToNonExistingUser_ReturnsFalse()
        {
            Assert.That(_uut.CreateDataEntry("invalid", poolName, 987, 89, 8, 33), Is.False);
        }

        [Test]
        public void CreateDataEntry_AddingData_ReturnsTrue()
        {
            Assert.That(_uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33), Is.True);
        }

        [Test]
        public void CreateDataEntry_Adding2DataEntries_ReturnsTrue()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);
            Thread.Sleep(1000);
            Assert.That(_uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33), Is.True);
        }

        [Test]
        public void CreateDataEntry_Adding4DataEntries_ReturnsTrue()
        {
            for (int i = 0; i < 3; i++)
            {
                _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);
                Thread.Sleep(1000);
            }
            Assert.That(_uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33), Is.True);
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SearchReveilsCount1ForDataSet()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);

            using (var db = new DatabaseContext())
            {
                var searchdata = from data in db.DataSet
                                 where data.PoolId == poolId
                                 select data;

                Assert.That(searchdata.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SearchReveilsCount1ForChlorineSet()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);

            using (var db = new DatabaseContext())
            {
                var searchdata = from data in db.ChlorineSet
                                 select data;

                Assert.That(searchdata.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SearchReveilsCount1ForPhSet()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);

            using (var db = new DatabaseContext())
            {
                var searchdata = from data in db.pHSet
                                 select data;

                Assert.That(searchdata.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SearchReveilsCount1ForTemperatureSet()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);

            using (var db = new DatabaseContext())
            {
                var searchdata = from data in db.TemperatureSet
                                 select data;

                Assert.That(searchdata.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SearchReveilsCount1ForHumiditySet()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);

            using (var db = new DatabaseContext())
            {
                var searchdata = from data in db.HumiditySet
                                 select data;

                Assert.That(searchdata.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void CreateDataEntry_AddingDataEntry_SetHasCorrectValue()
        {
            double value = 987;

            string start = DateTime.UtcNow.ToString("G"); Thread.Sleep(1000);
            _uut.CreateDataEntry(ownerEmail, poolName, value, 89, 8, 33);
            string end = DateTime.UtcNow.ToString("G"); Thread.Sleep(1000);

            double setvalue = _uut.GetChlorineValues(ownerEmail, poolName, 2).First().Item2;

            Assert.That(setvalue, Is.EqualTo(value));
        }

        //[Test]
        //public void CreateDataEntry_AddingDataEntry_ReturnsTupleWithTimestampLessThanNow()
        //{
        //    double value = 987;

        //    Thread.Sleep(1000);
        //    string start = DateTime.UtcNow.ToString("G");
        //    _uut.CreateDataEntry(ownerEmail, poolName, value, 89, 8, 33);
        //    Thread.Sleep(1000);
        //    string end = DateTime.UtcNow.ToString("G");

        //    string settime = _uut.GetChlorineValues(ownerEmail, poolName, 2).First().Item1;

        //    Assert.That(DateTime.ParseExact(settime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), Is.LessThan(DateTime.ParseExact(end, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)));
        //}

        //[Test]
        //public void CreateDataEntry_AddingDataEntry_ReturnsTupleWithTimestampMoreThanBeforeMethodCall()
        //{
        //    double value = 987;

        //    Thread.Sleep(1000);
        //    string start = DateTime.UtcNow.ToString("G");
        //    _uut.CreateDataEntry(ownerEmail, poolName, value, 89, 8, 33);
        //    Thread.Sleep(1000);
        //    string end = DateTime.UtcNow.ToString("G");

        //    string settime = _uut.GetChlorineValues(ownerEmail, poolName, 2).First().Item1;

        //    Assert.That(DateTime.ParseExact(settime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), Is.AtLeast(DateTime.ParseExact(start, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)));
        //}

        #endregion

        #region DeleteAllData

        [Test]
        public void DeleteAllData_AddedDataToSomePools_NoDataInDatabase()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 78, 89, 8, 33);
            _uut.CreateDataEntry(ownerEmail, poolName, 78, 89, 8, 33);
            _uut.CreateDataEntry(ownerEmail, poolName, 78, 89, 8, 33);

            _uut.DeleteAllData();

            int entries = 0;

            using (var db = new DatabaseContext())
            {
                var search = from data in db.ChlorineSet
                             select data;

                entries = search.Count();
            }

            Assert.That(entries, Is.EqualTo(0));
        }

        #endregion

        #region GetData Methods

        #region GetPhData

        [Test]
        public void GetPhData_PhDataIsInDatabase_ReturnsListOfTuplesWithRightSensorType()
        {
            double pH = 8;
            string start = DateTime.UtcNow.ToString("G");
            _uut.CreateDataEntry(ownerEmail, poolName, 8, 89, 8, 33);
            var tuples = (_uut.GetPhValues(ownerEmail, poolName, 2));
            Assert.That(tuples.First().Item1, Is.EqualTo(SensorTypes.Ph));

        }

        public void GetPhData_PhDataIsInDatabase_ReturnsListOfTuplesWithRightValue()
        {
            double pH = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, pH, 89, 8, 33);
            var tuples = (_uut.GetPhValues(ownerEmail, poolName, 2));
            Assert.That(tuples.First().Item2, Is.EqualTo(pH));

        }

        [Test]
        public void GetPhData_PhDataNotPresent_ReturnsEmptyList()
        {
            var tuples = (_uut.GetPhValues(ownerEmail, poolName, 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetPhData_CallWithNonExistingEmail_ReturnsEmptyList()
        {
            double pH = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, pH, 89, 8, 33);
            var tuples = (_uut.GetPhValues("nonExistingMail", poolName, 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetPhData_CallWithNonExistingPoolName_ReturnsEmptyList()
        {
            double pH = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, pH, 89, 8, 33);
            var tuples = (_uut.GetPhValues(ownerEmail, "nonExistingPoolName", 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetPhData_CallWithNegativeDays_ReturnsEmptyList()
        {
            double pH = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, 15, 89, pH, 33);
            var tuples = (_uut.GetPhValues(ownerEmail, poolName, -2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetPhData_CallWithHigherDaysThanPersistedWhenDataIsPresent_ReturnsListWithOnlyDataPresent()
        {
            double pH = 2;
            _uut.CreateDataEntry(ownerEmail, poolName, 5, 89, pH, 33);
            var tuples = _uut.GetPhValues(ownerEmail, poolName, 20);
            Assert.That(tuples.First().Item2, Is.EqualTo(pH));

        }

        [Test]
        public void GetPhData_CallWithHigherDaysThanPersistedWhenDataIsNotPresent_ReturnsListWithOnlyDataPresent()
        {
            var tuples = _uut.GetPhValues(ownerEmail, poolName, 20);
            Assert.That(tuples, Is.Empty);
        }
        #endregion

        #region GetChlorineData
        [Test]
        public void GetChlorineData_ChlorineDataIsInDatabase_ReturnsListOfTuplesWithSensorTypeAndValues()
        {
            double chlorine = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = (_uut.GetChlorineValues(ownerEmail, poolName, 2));
            Assert.That(tuples.First().Item1, Is.EqualTo(SensorTypes.Chlorine));
        }

        [Test]
        public void GetChlorineData_ChlorineDataNotPresent_ReturnsEmptyList()
        {
            var tuples = (_uut.GetChlorineValues(ownerEmail, poolName, 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetChlorineData_CallWithNonExistingEmail_ReturnsEmptyList()
        {
            double chlorine = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = (_uut.GetChlorineValues("nonExistingMail", poolName, 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetChlorineData_CallWithNonExistingPoolName_ReturnsEmptyList()
        {
            double chlorine = 8;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = (_uut.GetChlorineValues(ownerEmail, "nonExistingPoolname", 2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetChlorineData_CallWithNegativeDays_ReturnsEmptyList()
        {
            double chlorine = 5;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = (_uut.GetPhValues(ownerEmail, poolName, -2));
            Assert.That(tuples, Is.Empty);
        }

        [Test]
        public void GetChlorineData_CallWithHigherDaysThanPersistedWhenDataIsPresent_ReturnsListWithOnlyDataPresent()
        {
            double chlorine = 5;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = _uut.GetChlorineValues(ownerEmail, poolName, 200);
            Assert.That(tuples.First().Item2, Is.EqualTo(chlorine));
        }

        [Test]
        public void GetChlorineData_CallWithHigherDaysThanPersistedWhenDataIsNotPresent_ReturnsEmptyList()
        {
            double chlorine = 5;
            _uut.CreateDataEntry(ownerEmail, poolName, chlorine, 89, 8, 33);
            var tuples = _uut.GetChlorineValues(ownerEmail, poolName, 200);
        }
        #endregion

        #region GetTemperatureData
        [Test]
        public void GetTemperatureData_TemperatureDataIsInDatabase_ReturnsListOfTuplesWithSensorTypeAndalues()
        {

        }

        [Test]
        public void GetTemperatureData_TemperatureDataNotPresent_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetTemperatureData_CallWithNonExistingEmail_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetTemperatureData_CallWithNonExistingPoolName_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetTemperatureData_CallWithNegativeDays_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetTemperatureData_CallWithHigherDaysThanPersistedWhenDataIsPresent_ReturnsListWithOnlyDataPresent()
        {

        }

        [Test]
        public void GetTemperatureData_CallWithHigherDaysThanPersistedWhenDataIsNotPresent_ReturnsListWithOnlyDataPresent()
        {

        }
        #endregion

        #region GetHumidityData

        [Test]
        public void GetHumidityData_HumidityDataIsInDatabase_ReturnsListOfTuplesWithSensorTypeAndalues()
        {

        }

        [Test]
        public void GetHumidityData_HumidityDataNotPresent_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetHumidityData_CallWithNonExistingEmail_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetHumidityData_CallWithNonExistingPoolName_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetHumidityData_CallWithNegativeDays_ReturnsEmptyList()
        {

        }

        [Test]
        public void GetHumidityData_CallWithHigherDaysThanPersistedWhenDataIsPresent_ReturnsListWithOnlyDataPresent()
        {

        }

        [Test]
        public void GetHumidityData_CallWithHigherDaysThanPersistedWhenDataIsNotPresent_ReturnsListWithOnlyDataPresent()
        {

        }

        #endregion

        #endregion
    }
}
