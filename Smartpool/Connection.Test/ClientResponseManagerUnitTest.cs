using NUnit.Framework;
using Smartpool.Connection.Model;

namespace Connection.Test
{
    [TestFixture]
    class ClientResponseManagerUnitTest
    {
        private ClientResponseManager _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ClientResponseManager();    
        }

        [Test]
        public void NoTestsImplemented()
        {
            Assert.That(true, Is.True);
        }
    }
}
