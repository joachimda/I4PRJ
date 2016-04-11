namespace ServerTest.Token
{
    public interface ITokenKeeperInternal
    {
        int GetAmountOfTokens();
        string CreateNewToken(string username);
        bool TokenActive(string username, string tokenString);
    }
}