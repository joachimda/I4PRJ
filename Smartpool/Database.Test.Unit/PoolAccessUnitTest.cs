using NSubstitute;
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

        private IPoolAccess _uut;
        private IUserAccess _userAccess;

        [SetUp]
        public void Setup()
        {
            _uut.DeleteAllPools();
            
            _uut = new PoolAccess();
            _userAccess = Substitute.For<IUserAccess>();

            //_userAccess.FindUserByEmail("lasse@emil.com").Returns(new User());
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameInUseReturnsTrue()
        {
            _uut.AddPool("lasse@emil.com", "derproad 12", "baghave lille", 30);

            Assert.That(_uut.IsPoolNameInUse("lasse@emil.com", "derproad 12", "baghave lille"), Is.True);
        }

        #endregion

        #region IsPoolNameInUse

        // tests

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_PoolNotInDatabase()
        {
            _uut.AddPool("jokke@mail.com", "Kærgaarden 78", "IndoorPewl", 25);
            _uut.RemovePool("jokke@mail.com", "Kærgaarden 78", "IndoorPewl");

            Assert.That(_uut.FindSpecificPool("jokke@mail.com", "Kærgaarden 78", "IndoorPewl"), Is.Null);
        }

        [Test]
        public void RemovePool_PoolNotPresentInDB_ThrowsPoolNotFoundException()
        {
            Assert.Throws<PoolNotFoundException>(() => _uut.RemovePool("jokke@mail.com", "Kærgaarden 78", "IndoorPewl"));
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