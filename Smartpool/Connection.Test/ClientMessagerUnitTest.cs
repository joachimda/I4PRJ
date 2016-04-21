using NSubstitute;
using NUnit.Framework;
using Smartpool.Connection.Model;

namespace Connection.Test
{
    [TestFixture]
    public class ClientMessagerUnitTest
    {
        private ClientMessager _uut;
        private IClientResponseManager _clientResponseManager;
        private IClient _client;

        [SetUp]
        public void Setup()
        {
            _client = Substitute.For<IClient>();
            //_client.StartClient().Returns(new LoginResponseMsg("TokenString", true));
            _clientResponseManager = Substitute.For<IClientResponseManager>();
            _uut = new ClientMessager(_client);


        }

        [Test]
        public void NoTestsImplemented()
        {
            Assert.That(true, Is.True);
        }
    }
}
