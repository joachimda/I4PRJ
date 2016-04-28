using System;
using NSubstitute;
using NUnit.Framework;
using Smartpool;

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

        }

        [Test]
        public void AddPool_AddingPoolWithNonNullUser_ThrowsUserNotFoundException()
        {

        }

        // public void AddPool_AddingPoolWithZeroVolume_ThrowsArgumentException()
        // public void AddPool_AddingPoolWith-5Volume_ThrowsArgumentException()
        // public void AddPool_AddingIdenticalPool_ThrowsArgumentException()
        // public void AddPool_AddingSecondPoolWithValidName_IsPoolNameInUseReturnsTrue()
        // public void AddPool_AddingPoolOnNewAddressWithExistingName_IsPoolNameInUseReturnsTrue()

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

        #endregion
    }
}