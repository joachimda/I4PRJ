using System.Collections.Generic;

namespace Smartpool.Connection.Server
{
    public class TokenKeeper : ITokenKeeper, ITokenKeeperInternal
    {
        private readonly List<IToken> _tokens = new List<IToken>();
        private readonly ITokenStringGenerator _tokenStringGenerator;
        private readonly int _tokenLifeTime;
        private readonly int _tokensCreatedBeforeRemovingUnused = 100;
        private int _removeUnusedCountdown;

        public TokenKeeper(ITokenStringGenerator tokenStringGenerator, int TokenLifeTimeMinutes)
        {
            _tokenStringGenerator = tokenStringGenerator;
            _tokenLifeTime = TokenLifeTimeMinutes;
            _removeUnusedCountdown = _tokensCreatedBeforeRemovingUnused;
        }

        public bool TokenActive(string username, string tokenString)
        {
            for (int index = 0; index < _tokens.Count; index++)
            {
                var token = _tokens[index];
                if (token.GetTokenOwner() == username && token.GetTokenString() == tokenString)
                {
                    if (token.TokenAlive())
                        return true;
                    else
                    {
                        _tokens.Remove(token);
                        index--;
                    }
                }
            }
            return false;
        }

        public string CreateNewToken(string username)
        {
            RemoveOldToken(username);
            var newToken = new Token(username, _tokenStringGenerator, _tokenLifeTime);
            _tokens.Add(newToken);

            if (_removeUnusedCountdown == 0)
            {
                RemoveAllUnusedTokens();
                _removeUnusedCountdown = _tokensCreatedBeforeRemovingUnused;
            }
            _removeUnusedCountdown--;

            return newToken.GetTokenString();
        }

        private void RemoveOldToken(string username)
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

        private void RemoveAllUnusedTokens()
        {
            for (int index = 0; index < _tokens.Count; index++)
            {
                var token = _tokens[index];
                if (!token.TokenAlive())
                {
                    _tokens.Remove(token);
                    index--;
                }
            }
        }

        public int GetAmountOfTokens()
        {
            return _tokens.Count;
        }
    }
}