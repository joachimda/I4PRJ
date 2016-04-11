using System.Collections.Generic;
using System.Globalization;

namespace Smartpool.Factories
{
    public interface IPoolAccess
    {
        bool AddPool(string email, string address, string name, double volume);
        bool IsPoolNameInUse(string email, string address, string name);
        Pool FindSpecific(string email, string address, string name);
        bool RemovePool(string email, string name);
        void DeleteAllPools();
    }
}