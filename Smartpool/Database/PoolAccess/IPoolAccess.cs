namespace Smartpool
{
    public interface IPoolAccess
    {
        void AddPool(User user, string address, string name, double volume);
        bool IsPoolNameInUse(User user, string address, string name);
        Pool FindSpecificPool(User user, string address, string name);
        void RemovePool(User user, string address, string name);
        void DeleteAllPools();
    }
}