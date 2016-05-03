namespace Smartpool
{
    public interface IPoolAccess
    {
        bool AddPool(string email, string name, double volume);
        bool IsPoolNameAvailable(string email, string name);
        Pool FindSpecificPool(string email, string name);
        bool RemovePool(string email, string name);
        void DeleteAllPools();
    }
}