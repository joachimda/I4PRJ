using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using Smartpool;
using Smartpool.Connection.Model;
using Smartpool.Connection.Server;

namespace Connection.Test
{
    [TestFixture]
    public class ResponseManagerUnitTest
    {
        private ResponseManager _uut;
        private ITokenKeeper _tokenKeeperSub;
        private ITokenMsgResponse _tokenMsgResponseSub;
        private ISmartpoolDB _smartpoolDbSub;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        [SetUp]
        public void SetUp()
        {
            _tokenKeeperSub = Substitute.For<ITokenKeeper>();
            _tokenMsgResponseSub = Substitute.For<ITokenMsgResponse>();
            _smartpoolDbSub = Substitute.For<ISmartpoolDB>();
            _uut = new ResponseManager(_tokenKeeperSub, _tokenMsgResponseSub, _smartpoolDbSub);

            _smartpoolDbSub.UserAccess.ValidatePassword("KnownEmail", "CorrectPassword").Returns(true);

            //_tokenMsgResponse.HandleTokenMsg(new TokenMsg("KnownEmail", "CorrectTokenString")).Returns(new TokenResponseMsg(true));

            _tokenKeeperSub.CreateNewToken("KnownEmail").Returns("CorrectTokenString");
            _tokenKeeperSub.TokenActive("KnownEmail", "CorrectTokenString").Returns(true);
            _tokenKeeperSub.TokenActive("KnownEmail", "IncorrectTokenString").Returns(false);
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

            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new LoginResponseMsg("", false) {MessageInfo = "Username or password was incorrect" })));
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

            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new LoginResponseMsg("", false) {MessageInfo = "Username or password was incorrect"})));
        }
        #endregion

        #region Test of Token case
        
        [Test]
        public void Respond_CorrectToken_ReturnsCorrectMessage()
        {
            var tokenRequestMessage = new TokenMsg("KnownEmail", "CorrectTokenString");
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(tokenRequestMessage, _jsonSettings);

            _uut.Respond(messageReceived);

            _tokenMsgResponseSub.Received().HandleTokenMsg(Arg.Any<TokenMsg>(),messageReceived, _tokenKeeperSub);
        }
        
        [Test]
        public void Respond_InCorrectToken_ReturnsCorrectMessage()
        {
            var tokenRequestMessage = new TokenMsg("KnownEmail", "IncorrectTokenString");
            tokenRequestMessage.Username = "KnownEmail";
            tokenRequestMessage.TokenString = "IncorrectTokenString";
            //Message received from client
            var messageReceived = JsonConvert.SerializeObject(tokenRequestMessage);
            //Answer from ResponseManager
            var messageSentBack = _uut.Respond(messageReceived);
            //Answer from ResponseManager in serialized form
            var serializedMessage = JsonConvert.SerializeObject(messageSentBack);
            
            Assert.That(serializedMessage, Is.EqualTo(JsonConvert.SerializeObject(new GeneralResponseMsg(false, false))));
            
        }
        
        #endregion

        #region Test of AddUser case



        #endregion

    }
}
