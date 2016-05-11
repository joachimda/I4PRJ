﻿using System.Collections.Generic;
using System.Linq;
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
        private User _testUser1, _testUser2;

        [SetUp]
        public void Setup()
        {
            _userAccess = new UserAccess();
            _uut = new PoolAccess(_userAccess);

            _testUser1 = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "somemail@derp.com", Password = "password123" };
            _testUser2 = new User() { Firstname = "Sire", Middelname = "Herp", Lastname = "Jensenei", Email = "post@jensenei.dk", Password = "mydogsname" };

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(_testUser1);
                db.UserSet.Add(_testUser2);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
            _uut.UserAccess.DeleteAllUsers();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPoolWithInvalidName_ReturnsFalse()
        {
            Assert.That(_uut.AddPool(_testUser1.Email, "", 4), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameAvailableReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "poolname", 4);

            Assert.That(_uut.IsPoolNameAvailable(_testUser1.Email, "poolname"), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithValidUser_ReturnsNull()
        {
            Assert.DoesNotThrow(() => _uut.AddPool(_testUser1.Email, "poolname", 89));
        }

        [Test]
        public void AddPool_AddingPoolWithZeroVolume_ReturnsFalse()
        {
            Assert.That(_uut.AddPool(_testUser1.Email, "name", 0), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithNeg5Volume_ReturnsFalse()
        {
            Assert.That(_uut.AddPool(_testUser1.Email, "name", -5), Is.False);
        }

        [Test]
        public void AddPool_AddingIdenticalPool_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "name", 4);
            Assert.That(_uut.AddPool(_testUser1.Email, "name", 4), Is.False);
        }

        [Test]
        public void AddPool_AddingSecondPoolWithValidName_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);
            bool shouldBeTrue = _uut.AddPool(_testUser1.Email, "othername", 3);
            Assert.That(shouldBeTrue, Is.True);
        }

        [Test]
        public void AddPool_AddingPoolToOtherUserWithSameName_ReturnTrue()
        {
            _uut.AddPool(_testUser2.Email, "name", 8);
            bool beTrue = _uut.AddPool(_testUser1.Email, "name", 8);
            Assert.That(beTrue, Is.True);
        }

        [Test]
        public void AddPool_AddingPoolToExistingUser_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _uut.AddPool(_testUser1.Email, "poolname", 4));
        }

        [Test]
        public void AddPool_AddingPoolToExistingUser_UserOnlyAppearOnceInDb()
        {
            // clear pools in db
            _uut.DeleteAllPools();
            _userAccess.RemoveUser(_testUser2.Email);

            // list to store found users in
            List<User> listOfFoundUsers = new List<User>();

            _uut.AddPool(_testUser1.Email, "poolname", 8);

            using (var db = new DatabaseContext())
            {
                var searchForUsers = from user in db.UserSet
                                     select user;

                foreach (User user in searchForUsers)
                {
                    listOfFoundUsers.Add(user);
                }
            }

            Assert.That(listOfFoundUsers.Count, Is.EqualTo(1));
        }

        #endregion

        #region IsPoolNameAvailable

        [Test]
        public void IsPoolNameAvailable_UserNotExisting_IsPoolNameAvailableReturnsTrue()
        {
            Assert.That(_uut.IsPoolNameAvailable("nonexistingemail@derp.dk", "somename"), Is.True);
        }

        [Test]
        public void IsPoolNameAvailable_PoolExists_IsPoolNameAvailableReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "unknown", 8);
            Assert.That(_uut.IsPoolNameAvailable(_testUser1.Email, "unknown"), Is.False);
        }

        [Test]
        public void IsPoolNameAvailable_AddedOtherOriginalPool_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);
            bool mustBeTrue = _uut.IsPoolNameAvailable(_testUser1.Email, "othername");

            Assert.That(mustBeTrue, Is.True);
        }

        #endregion

        #region FindSpecificPool

        [Test]
        public void FindSpecificPool_EmptyDatabase_ThrowsPoolNotFoundException()
        {
            User derp = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "post@andersen.dk" };

            Assert.Throws<PoolNotFoundException>(() => _uut.FindSpecificPool(derp.Email, "thispooldoesnotexist"));
        }

        [Test]
        public void FindSpecificPool_UserExistsInDatabaseButWithoutPool_ThrowsPoolNotFoundException()
        {
            Assert.Throws<PoolNotFoundException>(() => _uut.FindSpecificPool(_testUser1.Email, "thispooldoesnotexist"));
        }

        [Test]
        public void FindSpecificPool_PoolIsInDatabase_ReturnsPoolWithCorrectName()
        {
            const string mail = "somemail@derp.com";
            _uut.AddPool(mail, "poolio", 50);

            Pool pool = _uut.FindSpecificPool(mail, "poolio");
            Assert.That(pool.Name, Is.EqualTo("poolio"));
        }

        [Test]
        public void FindSpecificPool_PoolIsInDatabase_ReturnsPoolWithCorrectUserId()
        {
            _uut.AddPool(_testUser1.Email, "poolio", 50);

            Pool pool = _uut.FindSpecificPool(_testUser1.Email, "poolio");
            Assert.That(pool.UserId, Is.EqualTo(_testUser1.Id));
        }

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_IsPoolNameAvailableReturnsTrue()
        {
            const string mail = "somemail@derp.com";
            string poolname = "helloworld";

            _uut.AddPool(mail, poolname, 9);
            _uut.RemovePool(mail, poolname);

            Assert.That(_uut.IsPoolNameAvailable(mail, poolname), Is.True);
        }

        [Test]
        public void RemovePool_PoolNotInDatabase_RemovePoolReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            Assert.That(_uut.RemovePool(mail, "ThisPoolIsNotHere"), Is.False);
        }

        #endregion

        #region Change Name

        [Test]
        public void EditPoolName_ChangeNameOfNotExistingPool_ReturnsFalse()
        {
            Assert.That(_uut.EditPoolName(_testUser1.Email, "nonexisting", "newname"), Is.False);
        }

        //[Test]
        //public void EditPoolName_ChangeNameOfNotExistingPool_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolName_ChangeNameOfExistingPoolToInvalid_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "oldname", 5);

            Assert.That(_uut.EditPoolName(_testUser1.Email, "oldname", ""), Is.False);
        }

        //[Test]
        //public void EditPoolName_ChangeNameOfExistingPoolToInvalid_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolName_ChangeNameOfExistingPoolToTakenName_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "takenname", 5);
            _uut.AddPool(_testUser1.Email, "nametochange", 5);

            Assert.That(_uut.EditPoolName(_testUser1.Email, "nametochange", "takenname"), Is.False);
        }

        //[Test]
        //public void EditPoolName_ChangeNameOfExistingPoolToTakenName_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolName_ChangeNameOfExistingPool_ReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "takenname", 5);
            _uut.AddPool(_testUser1.Email, "nametochange", 5);

            Assert.That(_uut.EditPoolName(_testUser1.Email, "nametochange", "newname"), Is.True);
        }

        [Test]
        public void EditPoolName_ChangeNameOfExistingPoolTo_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "nametochange", 5);
            _uut.EditPoolName(_testUser1.Email, "nametochange", "newname");

            Assert.That(_uut.IsPoolNameAvailable(_testUser1.Email, "nametochange"), Is.True);
        }

        #endregion

        #region Change Volume

        [Test]
        public void EditPoolVolume_ChangeVolumeOfNotExistingPool_ReturnsFalse()
        {
            Assert.That(_uut.EditPoolVolume(_testUser1.Email, "unknown", 4), Is.False);
        }

        [Test]
        public void EditPoolVolume_ChangeVolumeOfExistingPoolTo0_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "unknown", 5);
            Assert.That(_uut.EditPoolVolume(_testUser1.Email, "unknown", 0), Is.False);
        }

        [Test]
        public void EditPoolVolume_ChangeVolumeOfExistingPoolToNeg1_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "unknown", 5);
            Assert.That(_uut.EditPoolVolume(_testUser1.Email, "unknown", -1), Is.False);
        }

        //[Test]
        //public void EditPoolVolume_ChangeVolumeOfExistingPoolToInvalid_FindSpecificPoolReturnsOriginalPool() { }

        [Test]

        public void EditPoolVolume_ChangeVolumeOfExistingPool_ReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "unknown", 5);

            Assert.That(_uut.EditPoolVolume(_testUser1.Email, "unknown", 9), Is.True);
        }

        [Test]
        public void EditPoolVolume_ChangeVolumeOfExistingPool_FindSpecificPoolReturnsNewPool()
        {
            _uut.AddPool(_testUser1.Email, "unknown", 5);
            _uut.EditPoolVolume(_testUser1.Email, "unknown", 9);

            Assert.That(_uut.FindSpecificPool(_testUser1.Email, "unknown").Volume, Is.EqualTo(9));
        }

        #endregion

        #region Change User

        [Test]
        public void EditPoolUser_ChangeUserOfNotExistingPool_ReturnsFalse()
        {
            Assert.That(_uut.EditPoolUser(_testUser1.Email, "nonexisting", _testUser2.Email), Is.False);
        }

        //[Test]
        //public void EditPoolUser_ChangeUserOfNotExistingPool_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolUser_ChangeUserToInvalid_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);

            Assert.That(_uut.EditPoolUser(_testUser1.Email, "name", "invaliduseremail"), Is.False);
        }

        //[Test]
        //public void EditPoolUser_ChangeUserToInvalid_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolUser_ChangeUserToSomeoneWhereNameIsTaken_ReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);
            _uut.AddPool(_testUser2.Email, "name", 8);

            Assert.That(_uut.EditPoolUser(_testUser1.Email, "name", _testUser2.Email), Is.False);
        }

        //[Test]
        //public void EditPoolUser_ChangeUserToSomeoneWhereNameIsTaken_FindSpecificPoolReturnsOriginalPool() { }

        [Test]
        public void EditPoolUser_ChangeUser_ReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);

            Assert.That(_uut.EditPoolUser(_testUser1.Email, "name", _testUser2.Email), Is.True);
        }

        [Test]
        public void EditPoolUser_ChangeUser_IsPoolNameAvailableReturnsTrue()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);
            _uut.EditPoolUser(_testUser1.Email, "name", _testUser2.Email);

            Assert.That(_uut.IsPoolNameAvailable(_testUser1.Email, "name"), Is.True);
        }

        [Test]
        public void EditPoolUser_ChangeUser_IsPoolNameAvailableReturnsFalse()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);
            _uut.EditPoolUser(_testUser1.Email, "name", _testUser2.Email);

            Assert.That(_uut.IsPoolNameAvailable(_testUser2.Email, "name"), Is.False);
        }

        #endregion

        #region FindAllPoolsOfUser

        [Test]
        public void FindAllPoolsOfUser_NullUser_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.FindAllPoolsOfUser("fakemail"));
        }

        [Test]
        public void FindAllPoolsOfUser_UserWith0Pools_ReturnEmptyList()
        {
            Assert.That(_uut.FindAllPoolsOfUser(_testUser1.Email).Count, Is.EqualTo(0));
        }

        [Test]
        public void FindAllPoolsOfUser_UserWith1Pool_ReturnsListWithCorrectPool()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);

            Assert.That(_uut.FindAllPoolsOfUser(_testUser1.Email).First().Name, Is.EqualTo("name"));
        }

        [Test]
        public void FindAllPoolsOfUser_UserWith1Pool_ReturnsListWithCount1()
        {
            _uut.AddPool(_testUser1.Email, "name", 8);

            Assert.That(_uut.FindAllPoolsOfUser(_testUser1.Email).Count, Is.EqualTo(1));
        }

        [Test]
        public void FindAllPoolsOfUser_UserWith10Pool_ReturnsListWithCount10()
        {
            for (int i = 0; i < 10; i++)
            {
                _uut.AddPool(_testUser1.Email, "name" + i, 8);
            }

            Assert.That(_uut.FindAllPoolsOfUser(_testUser1.Email).Count, Is.EqualTo(10));
        }

        [Test]
        public void FindAllPoolsOfUser_UserWith10Pools_ReturnsListWithCorrectPools()
        {
            for (int i = 0; i < 10; i++)
            {
                _uut.AddPool(_testUser1.Email, "name" + i, 8);
            }

            Assert.That(_uut.FindAllPoolsOfUser(_testUser1.Email)[5].Name, Is.EqualTo("name5"));
        }

        #endregion
    }
}