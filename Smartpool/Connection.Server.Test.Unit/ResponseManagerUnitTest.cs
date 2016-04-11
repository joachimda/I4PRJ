using NUnit.Framework;
using ServerTest;
using ServerTest.Token;
using NSubstitute;

namespace Connection.Server.Test.Unit
{
    [TestFixture]
    public class ResponseManagerUnitTest
    {
        private IResponseManager _uut;
        private ITokenKeeper _subTokenKeeper;

        [SetUp]
        public void SetUp()
        {
            _subTokenKeeper = Substitute.For<ITokenKeeper>();
            _uut = new ResponseManager(new TokenStringGenerator(), _subTokenKeeper);

            _subTokenKeeper.CreateNewToken("Joachim").Returns("TokenStr");
            _subTokenKeeper.TokenActive("Joachim","TokenStr").Returns(true);
            _subTokenKeeper.TokenActive("Joachim","Token").Returns(false);
        }

        [Test]
        public void Respond_ReceivedUsernameForSignePasswordForSigne_ReturnsStringLoginCommaTokenStr()
        {
            Assert.That(_uut.Respond("Login,Joachim,password,<EOF>"), Is.EqualTo("Login,TokenStr"));
        }

        [Test]
        public void Respond_IncorrectTokenRetrievingTemp_ReturnsSessionExpired()
        {
            Assert.That(_uut.Respond("GetTemp,Joachim,Token,<EOF"), Is.EqualTo("Session Expired"));
        }

        [Test]
        public void Respond_CorrectTokenRetrievingTemp_ReturnsTemperature()
        {
            Assert.That(_uut.Respond("GetTemp,Joachim,TokenStr,<EOF"), Is.EqualTo("Temperature in pool is 25 degrees"));
        }
    }
}
