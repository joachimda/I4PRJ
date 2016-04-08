using System;
using System.Text;

namespace ServerTest.Token
{
    public class TokenStringGenerator : ITokenStringGenerator
    {
        private const int StringLenght = 8;
        private readonly Random _rnd = new Random();
        private readonly StringBuilder _builder = new StringBuilder();

        public string GenerateTokenString()
        {
            for (int i = 0; i < StringLenght; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*_rnd.NextDouble() + 65)));
                _builder.Append(ch);
            }
            return _builder.ToString();
        }
    }
}