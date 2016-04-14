namespace Smartpool.Connection.Server.Token
{
    public interface IToken
    {
        string GetTokenOwner();
        string GetTokenString();
        void RefreshToken();
        bool TokenAlive();
    }
}