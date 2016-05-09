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

        string email, nameOfPool;

        [SetUp]
        public void Setup()
        {
            nameOfPool = "baghave";
            email = "hansen @gmail.com";

            _userAccess = new UserAccess();
            _poolAccess = new PoolAccess(_userAccess);
            _uut = new DataAccess(_poolAccess);

            _userAccess.AddUser("Sir Derp Hansen", email, "hanpassword");
            _poolAccess.AddPool(email, nameOfPool, 8);
            _uut.AddData(email, nameOfPool);
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllData();
            _poolAccess.DeleteAllPools();
            _userAccess.DeleteAllUsers();
        }

        #endregion

        #region AddData

        [Test]
        public void AddData_AddingDataToNonExistingPoolAndUser_ReturnsFalse()
        {
            Assert.That(_uut.AddData("mail", "somepool"), Is.False);
        }

        [Test]
        public void AddData_AddingDataToNonExistingPool_ReturnsFalse()
        {
            Assert.That(_uut.AddData(email, "somepool"), Is.False);
        }

        [Test]
        public void AddData_AddingDataToNonExistingUser_ReturnsFalse()
        {
            Assert.That(_uut.AddData("user", nameOfPool), Is.False);
        }

        [Test]
        public void AddData_AddingDataToPoolWithExistingData_ReturnsFalse()
        {
            _uut.AddData(email, nameOfPool);

            Assert.That(_uut.AddData(email, nameOfPool), Is.False);
        }

        [Test]
        public void AddData_AddingData_ReturnsTrue()
        {
            Assert.That(_uut.AddData(email, nameOfPool), Is.True);
        }

        #endregion

        #region RemoveData

        [Test]
        public void RemoveData_RemovingDataFromNonExistingPoolAndUser_ReturnsFalse() { }

        [Test]
        public void RemoveData_RemovingDataFromNonExistingPool_ReturnsFalse() { }

        [Test]
        public void RemoveData_RemovingDataFromNonExistingUser_ReturnsFalse() { }

        [Test]
        public void RemoveData_RemovingDataFromPoolWithoutData_ReturnsFalse() { }

        [Test]
        public void RemoveData_RemovingData_ReturnsFalse() { }

        #endregion

        #region DeleteAllData

        [Test]
        public void DeleteAllData_AddedDataToSomePools_NoDataSetInDatabase() { }

        [Test]
        public void DeleteAllData_EmptyDatabase_NoDataSetInDatabase() { }

        #endregion

    }
}