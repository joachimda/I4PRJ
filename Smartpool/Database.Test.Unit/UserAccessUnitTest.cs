using NUnit.Framework;
using Smartpool.UserAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class UserAccessUnitTest
    {
        #region Setup

        IUserAccess _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new UserAccess();
        }

        #endregion

        [Test]
        public void AddUser_DoesNotAddUser_NUnitIsWorking()
        {
            Assert.That(5, Is.EqualTo(5));
        }
    }
}
