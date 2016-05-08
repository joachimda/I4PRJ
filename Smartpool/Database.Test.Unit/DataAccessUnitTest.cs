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

        [SetUp]
        public void Setup()
        {
            _uut = new DataAccess();
            _userAccess = new UserAccess();
            _poolAccess = new PoolAccess(_userAccess);

            _userAccess.AddUser("Sir Derp Hansen", "hansen@gmail.com", "hanpassword");
            _poolAccess.AddPool("hansen@gmail.com", "baghave", 8);
            _uut.AddData("hansen@gmail.com", "baghave");
        }

        [TearDown]
        public void Teardown()
        {
            _poolAccess.DeleteAllPools();
            _userAccess.DeleteAllUsers();
            _uut.DeleteAllData();
        }

        #endregion

        #region AddData

        // public void AddData_AddingDataToNonExistingPoolAndUser_ReturnsFalse()
        // public void AddData_AddingDataToNonExistingPool_ReturnsFalse()
        // public void AddData_AddingDataToNonExistingUser_ReturnsFalse()
        // public void AddData_AddingDataToPoolWithExistingData_ReturnsFalse()
        // public void AddData_AddingData_ReturnsFalse()

        #endregion

        #region RemoveData

        // public void RemoveData_RemovingDataFromNonExistingPoolAndUser_ReturnsFalse()
        // public void RemoveData_RemovingDataFromNonExistingPool_ReturnsFalse()
        // public void RemoveData_RemovingDataFromNonExistingUser_ReturnsFalse()
        // public void RemoveData_RemovingDataFromPoolWithoutData_ReturnsFalse()
        // public void RemoveData_RemovingData_ReturnsFalse()

        #endregion
    }
}