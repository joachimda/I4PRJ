namespace Smartpool
{
    public interface IPoolAccess
    {
        bool AddPool(User user, string address, string name, double volume);
        bool IsPoolNameInUse(string email, string address, string name);
        Pool FindSpecificPool(string email, string address, string name);
        void RemovePool(string email, string address, string name);
        void DeleteAllPools();
    }
}