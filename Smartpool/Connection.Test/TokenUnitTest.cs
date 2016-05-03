using System.Threading;
using NUnit.Framework;

namespace Connection.Test
{
    [TestFixture]
    public class TokenUnitTest
    {
        private ITokenStringGenerator _uut_TSG;
        private IToken _uut_Token;
        private ITokenKeeperInternal _uut_TK;


        [SetUp]
        public void Setup()
        {
            _uut_TSG = new TokenStringGenerator();
            _uut_Token = new Token("Joachim", _uut_TSG, 1);
            _uut_TK = new TokenKeeper(_uut_TSG, 1);
        }
        #region TokenStringGenerator tests
        [Test]
        public void GenerateTokenString_ReturnsEightCharString()
        {
            Assert.That(_uut_TSG.GenerateTokenString().Length, Is.EqualTo(8));
        }
        #endregion

        #region Token tests
        [Test]
        public void TokenAlive_StillActive_ReturnsTrue()
        {
            Assert.That(_uut_Token.TokenAlive, Is.True);
        }

        [Test]
        public void TokenAlive_NotActive_ReturnsFalse()
        {
            _uut_Token = new Token("Joachim", _uut_TSG, 0);
            Thread.Sleep(1);
            Assert.That(_uut_Token.TokenAlive, Is.False);
        }
        #endregion

        #region TokenKeeper tests
        [Test]
        public void CreateNewToken_NewTokenCreated_ListLenghtOne()
        {
            _uut_TK.CreateNewToken("Joachim");
            Assert.That(_uut_TK.GetAmountOfTokens(), Is.EqualTo(1));
        }

        [Test]
        public void CreateNewToken_SameTokenCreated_NoDuplicates()
        {
            _uut_TK.CreateNewToken("Joachim");
            _uut_TK.CreateNewToken("Joachim");
            _uut_TK.CreateNewToken("Joachim");
            _uut_TK.CreateNewToken("Morten");
            _uut_TK.CreateNewToken("Morten");
            _uut_TK.CreateNewToken("Morten");
            Assert.That(_uut_TK.GetAmountOfTokens(), Is.EqualTo(2));
        }

        [Test]
        public void StillActive_CorrectUserAndString_ReturnsTrue()
        {
            var tokenString = _uut_TK.CreateNewToken("Joachim");
            Assert.That(_uut_TK.TokenActive("Joachim", tokenString), Is.True);
        }

        [Test]
        public void StillActive_IncorrectUserAndString_ReturnsFalse()
        {
            _uut_TK.CreateNewToken("Joachim");
            Assert.That(_uut_TK.TokenActive("Joachim", "IncorrectToken"), Is.False);
        }

        [Test]
        public void NotActive_CorrectUserAndString_ReturnsFalse()
        {
            _uut_TK = new TokenKeeper(_uut_TSG, 0);
            var tokenString = _uut_TK.CreateNewToken("Joachim");
            Assert.That(_uut_TK.TokenActive("Joachim", tokenString), Is.False);
        }

        //Tests that each time 101 tokens are created, expired tokens will be removed.
        //Tokens are created with lifetime = 0, so all will be removed
        [Test]
        public void RemoveOldTokens_OneHundredTokensCreated_OldTokensRemoved()
        {
            _uut_TK = new TokenKeeper(_uut_TSG, 0);

            for (int i = 0; i < 20; i++)
            {
                _uut_TK.CreateNewToken("Joachim");
                _uut_TK.CreateNewToken("Bjorn");
                _uut_TK.CreateNewToken("Lasse");
                _uut_TK.CreateNewToken("Alex");
                _uut_TK.CreateNewToken("Emil");
            }
            _uut_TK.CreateNewToken("Joachim");
            var tokensInKepper = _uut_TK.GetAmountOfTokens();

            Assert.That(tokensInKepper, Is.EqualTo(0));
        }

        #endregion
    }
}