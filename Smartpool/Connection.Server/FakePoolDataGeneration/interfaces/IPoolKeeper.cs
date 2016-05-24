namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public interface IPoolKeeper
    {
        void GeneratePoolsForUser(string username);
        void AddPoolToKeeper(string username, string poolName);
    }
}