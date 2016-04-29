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
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameAvailableReturnsFalse()
        {
            _uut.AddPool(_user1, "poolname", 4);

            Assert.That(_uut.IsPoolNameAvailable(_user1, "poolname"), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithValidUser_ThrowsUserNotFoundException()
        {
            Assert.DoesNotThrow(() => _uut.AddPool(_user1, "poolname", 89));
        }

        [Test]
        public void AddPool_AddingPoolWithZeroVolume_ReturnsFalse()
        {
            Assert.That(_uut.AddPool(_user1, "name", 0), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithNeg5Volume_ReturnsFalse()
        {
            Assert.That(_uut.AddPool(_user1, "name", -5), Is.False);
        }

        [Test]
        public void AddPool_AddingIdenticalPool_ReturnsFalse()
        {
            _uut.AddPool(_user1, "name", 4);
            Assert.That(_uut.AddPool(_user1, "name", 4), Is.False);
        }

        [Test]
        public void AddPool_AddingSecondPoolWithValidName_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_user1, "name", 8);

            bool shouldBeTrue = _uut.AddPool(_user1, "othername", 3);

            Assert.That(shouldBeTrue, Is.True);
        }

        [Test]
        public void AddPool_AddingPoolToOtherUserWithSameName_ReturnTrue()
        {
            _uut.AddPool(_user2, "name", 8);

            bool beTrue = _uut.AddPool(_user1, "name", 8);

            Assert.That(beTrue, Is.True);
        }

        #endregion

        #region IsPoolNameAvailable

        [Test]
        public void IsPoolNameAvailable_EmptyDatabase_IsPoolNameAvailableReturnsTrue()
        {
            Assert.That(_uut.IsPoolNameAvailable(_user1, "somename"), Is.True);
        }

        [Test]
        public void IsPoolNameAvailable_PoolExists_IsPoolNameAvailableReturnsFalse()
        {
            _uut.AddPool(_user2, "unknown", 8);
            Assert.That(_uut.IsPoolNameAvailable(_user2, "unknown"), Is.False);
        }

        [Test]
        public void IsPoolNameAvailable_AddedOtherOriginalPool_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_user1, "name", 8);

            bool mustBeTrue = _uut.IsPoolNameAvailable(_user1, "othername");

            Assert.That(mustBeTrue, Is.True);
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
            _uut.AddPool(_user1, "poolio", 50);

            Pool pool = _uut.FindSpecificPool(_user1, "poolio");
            Assert.That(pool.Name, Is.EqualTo("poolio"));

        }

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_IsPoolNameAvailableReturnsTrue()
        {
            string poolname = "helloworld";

            _uut.AddPool(_user1, poolname, 9);
            _uut.RemovePool(_user1, poolname);

            Assert.That(_uut.IsPoolNameAvailable(_user1, poolname), Is.True);
        }

        [Test]
        public void RemovePool_PoolNotInDatabase_RemovePoolReturnsFalse()
        {
            Assert.That(_uut.RemovePool(_user1, "ThisPoolIsNotHere"), Is.False);
        }

        #endregion
    }
}