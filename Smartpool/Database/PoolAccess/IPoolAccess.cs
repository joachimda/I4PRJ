using System.Globalization;

namespace Smartpool.Factories
{
    public interface IPoolAccess
    {
        bool AddPool(string userEmail, string name, double volume);
        bool IsPoolNameInUse(string userEmail, string name);
        bool RemovePool(string email, string name);
        void DeleteAllPools();
    }
}