using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Smartpool.Connection.Model;

namespace Connection.Model.Test.Unit
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
        public void test()
        {
            
        }
    }
}
