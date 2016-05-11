using System.Linq;
using System.Threading;
using NUnit.Framework;
using Smartpool;

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
        public void CreateDataEntry_AddingDataEntry_()
        {
            _uut.CreateDataEntry(ownerEmail, poolName, 987, 89, 8, 33);
            
            //Assert.That(_uut.);
        }

        #endregion

        #region RemoveData

        //[Test]
        //public void RemoveData_RemovingDataFromNonExistingPoolAndUser_ReturnsFalse() { }

        //[Test]
        //public void RemoveData_RemovingDataFromNonExistingPool_ReturnsFalse() { }

        //[Test]
        //public void RemoveData_RemovingDataFromNonExistingUser_ReturnsFalse() { }

        //[Test]
        //public void RemoveData_RemovingDataFromPoolWithoutData_ReturnsFalse() { }

        //[Test]
        //public void RemoveData_RemovingData_ReturnsFalse() { }

        #endregion

        #region DeleteAllData

        //[Test]
        //public void DeleteAllData_AddedDataToSomePools_NoDataSetInDatabase() { }

        //[Test]
        //public void DeleteAllData_EmptyDatabase_NoDataSetInDatabase() { }

        #endregion

    }
}