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

        private User _user1, _user2;

        [SetUp]
        public void Setup()
        {
            _uut = new PoolAccess();
            _userAccess = new UserAccess();

            _user1 = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "post@andersen.dk", Password = "password123" };
            _user2 = new User() { Firstname = "Sire", Middelname = "Herp", Lastname = "Jensenei", Email = "post@jensenei.dk", Password = "mydogsname" };

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(_user1);
                db.UserSet.Add(_user2);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
            _userAccess.DeleteAllUsers();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameInUseReturnsTrue()
        {
            _uut.AddPool(_user1, "poolname", 4);

            Assert.That(_uut.IsPoolNameInUse(_user1, "poolname"), Is.True);
        }

        [Test]
        public void AddPool_AddingPoolWithNonNullUser_ThrowsUserNotFoundException()
        {

        }

        [Test]
        public void AddPool_AddingPoolWithZeroVolume_ThrowsArgumentException()
        {

        }

        [Test]
        public void AddPool_AddingPoolWithNeg5Volume_ThrowsArgumentException()
        {

        }

        [Test]
        public void AddPool_AddingIdenticalPool_ThrowsArgumentException()
        {

        }

        [Test]
        public void AddPool_AddingSecondPoolWithValidName_IsPoolNameInUseReturnsTrue()
        {

        }

        [Test]
        public void AddPool_AddingPoolOnNewAddressWithExistingName_IsPoolNameInUseReturnsTrue()
        {

        }

        #endregion

        #region IsPoolNameInUse

        [Test]
        public void IsPoolNameInUse_EmptyDatabase_ReturnsFalse()
        {

        }

        [Test]
        public void IsPoolNameInUse_EmptyDatabase_ThrowsUserNotFoundException()
        {

        }

        [Test]
        public void IsPoolNameInUse_EmptyDatabase_ThrowsPoolNotFoundException()
        {

        }

        [Test]
        public void IsPoolNameInUse_AddedOtherOriginalPool_ReturnsFalse()
        {
            
        }

        [Test]
        public void IsPoolNameInUse_PoolOnSameUserAndAddress_ReturnsFalse()
        {
            
        }

        [Test]
        public void IsPoolNameInUse_PoolOnSameUserAndAddressAndName_ReturnsTrue()
        {

        }

        #endregion

        #region FindSpecificPool

        [Test]
        public void FindSpecificPool_EmptyDatabase_ThrowsUserNotFoundException()
        {
            
        }

        [Test]
        public void FindSpecificPool_EmptyDatabase_ThrowsPoolNotFoundException()
        {
            
        }

        [Test]
        public void FindSpecificPool_UserExistsInDatabase_ThrowsPoolNotFoundException()
        {
            
        }

        [Test]
        public void FindSpecificPool_PoolIsInDatabase_ReturnsCorrectPool()
        {
            
        }

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_IsPoolNameInUseReturnsFalse()
        {

        }

        [Test]
        public void RemovePool_PoolNotInDatabase_ThrowsPoolNotFoundException()
        {

        }

        #endregion
    }
}