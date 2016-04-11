﻿using System.Collections.Generic;
using System.Globalization;

namespace Smartpool.Factories
{
    public interface IPoolAccess
    {
        bool AddPool(string email, string address, string name, double volume);
        bool IsPoolNameInUse(string email, string address, string name);
        Pool FindSpecificPool(string email, string address, string name);
        bool RemovePool(string email, string address, string name);
        void DeleteAllPools();
    }
}