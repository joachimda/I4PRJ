using NUnit.Framework;
using Smartpool;
using Smartpool.Factories;
using Smartpool.UserAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class PoolAccessUnitTest
    {
        #region Setup

        IPoolAccess _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new PoolAccess();
            _uut.DeleteAllPools();
        }

        [TearDown]
        public void Teardown()
        {
            //_uut.DeleteAllPools();
        }

        #endregion

        #region AddPool

        // tests

        #endregion

        #region IsPoolNameInUse

        // tests

        #endregion

        #region RemovePool

        // tests

        #endregion

        #region DeleteAllPools

        [Test]
        public void RemovePool_RemoveExistingPool_PoolNotInDatabase()
        {
            _uut.AddPool("jokke@mail.com","Kærgaarden 78", "IndoorPewl", 25);
            _uut.RemovePool("jokke@mail.com", "Kærgaarden 78", "IndoorPewl");

            Assert.That(_uut.FindSpecificPool("jokke@mail.com","Kærgaarden 78", "IndoorPewl"), Is.Null);
        }
        /*
        [Test]
        public void RemoveUser_UserNotPresentInDB_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.RemoveUser("jokkemail"));
        }
        */
        #endregion
    }
}