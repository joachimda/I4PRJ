namespace Smartpool.Connection.Server
{
    public interface IToken
    {
        string GetTokenOwner();
        string GetTokenString();
        void RefreshToken();
        bool TokenAlive();
    }
}