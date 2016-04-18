using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using NSubstitute;
using Smartpool.Connection.Model;
using Smartpool.Connection.Server;
using Smartpool.Connection.Server.ResponseManager;
using Smartpool.Connection.Server.Token;
using Newtonsoft.Json;
using Smartpool;

namespace Connection.Server.Test.Unit
{
    [TestFixture]
    public class ResponseManagerUnitTest
    {
        private ResponseManager _uut;
        private ITokenKeeper _tokenKeeper;
        private ITokenMsgResponse _tokenMsgResponse;
        private ISmartpoolDB _smartpoolDb;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        [SetUp]
        public void SetUp()
        {
            _tokenKeeper = Substitute.For<ITokenKeeper>();
            _tokenMsgResponse = Substitute.For<ITokenMsgResponse>();
            _smartpoolDb = Substitute.For<ISmartpoolDB>();
            _uut = new ResponseManager(_tokenKeeper, _tokenMsgResponse, _smartpoolDb);

            _smartpoolDb.UserAccess.ValidatePassword("KnownEmail", "CorrectPassword").Returns(true);

            //_tokenMsgResponse.HandleTokenMsg(new TokenMsg("KnownEmail", "CorrectTokenString")).Returns(new TokenResponseMsg(true));

            _tokenKeeper.CreateNewToken("KnownEmail").Returns("CorrectTokenString");
            _tokenKeeper.TokenActive("KnownEmail", "CorrectTokenString").Returns(true);
            _tokenKeeper.TokenActive("KnownEmail", "IncorrectTokenString").Returns(false);
        }

#region Test of Login case
        [Test]
        public void Respond_ReceivedKnownUsernameAndCorrectPassword_ReturnsCorrectLoginResponseMsg()
        {
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(new LoginRequestMsg("KnownEmail", "CorrectPassword"));
            //Answer from ResponseManager
            var messageSentBack = _uut.Respond(messageReceived);
            //Answer from ResponseManager in serialized form
            var serializedMessage = JsonConvert.SerializeObject(messageSentBack);
            
            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new LoginResponseMsg("CorrectTokenString", true))));
        }

        [Test]
        public void Respond_ReceivedKnownUsernameButIncorrectPassword_ReturnsCorrectLoginResponseMsg()
        {
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(new LoginRequestMsg("KnownEmail", "WrongPassword"));
            //Answer from ResponseManager
            var messageSentBack = _uut.Respond(messageReceived);
            //Answer from ResponseManager in serialized form
            var serializedMessage = JsonConvert.SerializeObject(messageSentBack);

            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new LoginResponseMsg("", false))));
        }

        [Test]
        public void Respond_ReceivedUnknownUsername_ReturnsCorrectLoginResponseMsg()
        {
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(new LoginRequestMsg("UnknownEmail", "CorrectPassword"));
            //Answer from ResponseManager
            var messageSentBack = _uut.Respond(messageReceived);
            //Answer from ResponseManager in serialized form
            var serializedMessage = JsonConvert.SerializeObject(messageSentBack);

            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new LoginResponseMsg("", false))));
        }
        #endregion

        #region Test of Token case
        [Test]
        public void Respond_CorrectToken_ReturnsCorrectMessage()
        {
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(new TokenRequestMsg("KnownEmail", "CorrectTokenString"), _jsonSettings);

            _uut.Respond(messageReceived);

            _tokenMsgResponse.Received().HandleTokenMsg(Arg.Any<TokenRequestMsg>());
        }

        [Test]
        public void Respond_InCorrectToken_ReturnsCorrectMessage()
        {
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(new TokenRequestMsg("KnownEmail", "IncorrectTokenString"));
            //Answer from ResponseManager
            var messageSentBack = _uut.Respond(messageReceived);
            //Answer from ResponseManager in serialized form
            var serializedMessage = JsonConvert.SerializeObject(messageSentBack);
            
            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new TokenResponseMsg(false))));
            
        }
        #endregion

        #region Test of AddUser case



        #endregion

    }
}
