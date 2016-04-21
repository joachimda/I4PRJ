namespace Smartpool.Connection.Server.Token
{
    public interface ITokenKeeper
    {
        string CreateNewToken(string username);
        bool TokenActive(string username, string tokenString);
    }
}