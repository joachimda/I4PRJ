using System;

namespace ServerTest.Token
{
    public class Token : IToken
    {
        private const int TokenActiveMinutes = 10;
        private readonly string _tokenString;
        private readonly string _tokenOwner;
        private DateTime _lastUseDateTime;
        
        public Token(string username, ITokenStringGenerator tokenStringGenerator)
        {
            _tokenString = tokenStringGenerator.GenerateTokenString();
            _tokenOwner = username;
            RefreshToken();
        }

        public bool TokenAlive()
        {
            if (DateTime.Now - _lastUseDateTime >= TimeSpan.FromMinutes(TokenActiveMinutes)) return false;
            RefreshToken();
            return true;
        }

        public string GetTokenOwner()
        {
            return _tokenOwner;
        }

        public string GetTokenString()
        {
            return _tokenString;
        }

        public void RefreshToken()
        {
            _lastUseDateTime = DateTime.Now;
        }
    }
}