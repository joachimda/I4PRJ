using NUnit.Framework;
using Smartpool;
using Smartpool.DataAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class WriteDataAccessUnitTest
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
        }

        #endregion

    }
}