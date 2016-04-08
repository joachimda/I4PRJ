using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServerTest.Token;

namespace Connection.Server.Test.Unit
{
    [TestFixture]
    public class TokenUnitTest
    {
        private ITokenStringGenerator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new TokenStringGenerator();
        }

        [Test]
        public void GenerateToken_ok()
        {
            Assert.That(_uut.GenerateTokenString().Length, Is.EqualTo("12345678".Length));
        }
    }
}


