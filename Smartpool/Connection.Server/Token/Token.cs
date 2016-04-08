using System;

namespace ServerTest.Token
{
    public class Token : IToken
    {
        private readonly int _tokenActiveMinutes;
        private readonly string _tokenString;
        private readonly string _tokenOwner;
        private DateTime _lastUseDateTime;
        
        public Token(string username, ITokenStringGenerator tokenStringGenerator, int tokenActiveMinutes = 10)
        {
            _tokenString = tokenStringGenerator.GenerateTokenString();
            _tokenActiveMinutes = tokenActiveMinutes;
            _tokenOwner = username;
            RefreshToken();
        }

        public bool TokenAlive()
        {
            if (DateTime.Now - _lastUseDateTime >= TimeSpan.FromMinutes(_tokenActiveMinutes)) return false;
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