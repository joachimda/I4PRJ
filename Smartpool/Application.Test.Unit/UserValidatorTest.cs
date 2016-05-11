//========================================================================
// FILENAME :   UserValidatorTest.cs
// DESCR.   :   Unit test of UserValidator
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using NUnit.Framework;
using Smartpool.Application.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class UserValidatorTest
    {
        private UserValidator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new UserValidator();
        }

        [Test]
        public void IsValidForLogin_CalledRightAfterConstruction_ReturnsFalse()
        {
            Assert.That(_uut.IsValidForLogin, Is.EqualTo(false));
        }

        [TestCase("12345678", "michael@mail.dk", true)]
        [TestCase("1234", "michael@mail.dk", true)]
        [TestCase("12345678", "", false)]
        [TestCase("", "michael", false)]
        [TestCase("", "", false)]
        public void IsValidForLogin_PropertiesSetToInputValues_CorrectReturnValue(string password, string email, bool valid)
        {
            _uut.Passwords[0] = password;
            _uut.Passwords[1] = password;
            _uut.Email = email;

            Assert.That(_uut.IsValidForLogin, Is.EqualTo(valid));
        }

        [Test]
        public void IsValidForSignup_CalledRightAfterConstruction_ReturnsFalse()
        {
            Assert.That(_uut.IsValidForSignup, Is.EqualTo(false));
        }

        [TestCase("12345678", "michael", "michael@mail.dk", true)]
        [TestCase("1234", "michael", "michael@mail.dk", false)]
        [TestCase("12345678", "", "michael@mail.dk", false)]
        [TestCase("12345678", "michael", "", false)]
        [TestCase("", "", "", false)]
        public void IsValidForSignup_PropertiesSetToInputValues_CorrectReturnValue(string password, string name, string email, bool valid)
        {
            _uut.Passwords[0] = password;
            _uut.Passwords[1] = password;
            _uut.Name = name;
            _uut.Email = email;

            Assert.That(_uut.IsValidForSignup, Is.EqualTo(valid));
        }

        [Test]
        public void PasswordIsValid_CalledRightAfterConstruction_ReturnsFalse()
        {
            Assert.That(_uut.PasswordIsValid, Is.EqualTo(false));
        }

        [TestCase("12345678", "charmander", false)]
        [TestCase("12345678", "12345678", true)]
        [TestCase("1234", "1234", true)]
        void PasswordIsValid_PasswordsSetToInputValues_CorrectReturnValue(string passwordOne, string passwordTwo, bool valid)
        {
            _uut.Passwords[0] = passwordOne;
            _uut.Passwords[1] = passwordTwo;

            Assert.That(_uut.PasswordIsValid, Is.EqualTo(valid));
        }
    }
}
