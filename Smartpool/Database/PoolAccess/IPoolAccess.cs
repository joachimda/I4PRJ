namespace Smartpool
{
    public interface IPoolAccess
    {
        bool AddPool(User user, string name, double volume);
        bool IsPoolNameInUse(User user, string name);
        Pool FindSpecificPool(User user, string name);
        bool RemovePool(User user, string name);
        void DeleteAllPools();
    }
}