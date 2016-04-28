namespace Smartpool.Connection.Server
{
    public interface ITokenKeeperInternal
    {
        int GetAmountOfTokens();
        string CreateNewToken(string username);
        bool TokenActive(string username, string tokenString);
    }
}