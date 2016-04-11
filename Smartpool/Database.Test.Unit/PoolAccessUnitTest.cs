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
            _uut.AddPool("Joachim Fucktard Andersen", "jokke@mail.com","jokkePassword", 25);
            _uut.RemovePool("jokkemail");

            Assert.That(_uut.FindPool("jokkemail", "",""), Is.Null);
        }

        [Test]
        public void RemoveUser_UserNotPresentInDB_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.RemoveUser("jokkemail"));
        }

        #endregion
    }
}