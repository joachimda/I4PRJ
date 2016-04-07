using System.Collections.Generic;
using System.Linq;

namespace ServerTest.Token
{
    public class TokenKeeper
    {
        private readonly List<IToken> _tokens = new List<IToken>();
        private readonly ITokenStringGenerator _tokenStringGenerator;

        public TokenKeeper(ITokenStringGenerator tokenStringGenerator)
        {
            _tokenStringGenerator = tokenStringGenerator;
        }

        public bool TokenActive(string username, string tokenString)
        {
            foreach (var token in _tokens)
            {
                if (token.GetTokenOwner() == username && token.GetTokenString() == tokenString)
                {
                    if (token.TokenAlive())
                        return true;
                }
            }
            return false;
        }

        public void CreateNewToken(string username)
        {
            CheckForOldToken(username);
            _tokens.Add(new Token(username, _tokenStringGenerator));
        }

        private void CheckForOldToken(string username)
        {
            foreach (var token in _tokens)
            {
                if (token.GetTokenOwner() == username)
                {
                    _tokens.Remove(token);
                    return;
                }
            }
        }
    }
}