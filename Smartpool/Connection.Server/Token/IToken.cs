namespace ServerTest.Token
{
    public interface IToken
    {
        string GetTokenOwner();
        string GetTokenString();
        void RefreshToken();
        bool TokenAlive();
    }
}