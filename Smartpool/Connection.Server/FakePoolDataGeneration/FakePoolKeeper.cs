using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public class FakePoolKeeper
    {
        private readonly List<FakePool> _fakePools = new List<FakePool>();
        private readonly ISmartpoolDB _smartpoolDb;
        private const int PoolUpdateTime = 60;

        public FakePoolKeeper(ISmartpoolDB smartpoolDb)
        {
            _smartpoolDb = smartpoolDb;
        }

        public void GeneratePoolsForUser(string userName)
        {
            var poolList = _smartpoolDb.PoolAccess.FindAllPoolsOfUser(userName);
            foreach (var pool in poolList)
            {
                _fakePools.Add(new FakePool(4, PoolUpdateTime, userName, pool.Name, _smartpoolDb));
                Thread.Sleep(1100);
            }
        }

        public void AddFakePoolToKeeper(string userName, string poolName)
        {
            _fakePools.Add(new FakePool(4, PoolUpdateTime, userName, poolName, _smartpoolDb));
        }

        public List<FakePool> GetPools()
        {
            return _fakePools;
        }
    }
}