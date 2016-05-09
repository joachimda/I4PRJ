using NUnit.Framework;
using Smartpool;
using Smartpool.DataAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class DataAccessUnitTest
    {
        #region Setup

        private IWriteDataAccess _uut;
        private IUserAccess _userAccess;
        private IPoolAccess _poolAccess;

        string ownerEmail, poolName;

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
        
        // public void CreateDataEntry_AddingData_DataPresentInDatabase(){}

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