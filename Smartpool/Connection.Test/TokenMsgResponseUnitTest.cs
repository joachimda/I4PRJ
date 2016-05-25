using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using Smartpool;
using Smartpool.Connection.Model;
using Smartpool.Connection.Server;

namespace Connection.Test
{
    [TestFixture]
    public class TokenMsgResponseUnitTest
    {
        private TokenMsgResponse _uut;
        private ISmartpoolDB _subForSmartpoolDb;
        private ITokenKeeper _subForTokenKeeper;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };


        [SetUp]
        public void Setup()
        {
            _subForSmartpoolDb = Substitute.For<ISmartpoolDB>();
            _subForTokenKeeper = Substitute.For<ITokenKeeper>();
            _uut = new TokenMsgResponse(_subForSmartpoolDb);
        }

        [Test]
        public void HandleTokenMsg_AddPoolRequest_ReturnGeneralResponse()
        {
            _subForSmartpoolDb.PoolAccess.AddPool("username", "poolName", 10).Returns(true);
            var apm = new AddPoolRequestMsg("username", "tokenString", "poolName", 10, "serialNumber");
            var addPoolMessageString =
                JsonConvert.SerializeObject(apm, _jsonSettings);
            var baseMsg = JsonConvert.DeserializeObject<Message>(addPoolMessageString);
            Assert.That(JsonConvert.SerializeObject(_uut.HandleTokenMsg(baseMsg, addPoolMessageString, _subForTokenKeeper)), Is.EqualTo(JsonConvert.SerializeObject(new GeneralResponseMsg(true, true))));
        }
        
    }
}
