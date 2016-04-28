namespace Smartpool.Connection.Server
{
    public interface ITokenKeeper
    {
        string CreateNewToken(string username);
        bool TokenActive(string username, string tokenString);
    }
}