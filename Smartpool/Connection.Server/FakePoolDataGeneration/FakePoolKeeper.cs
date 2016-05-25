using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;

namespace Smartpool.Connection.Server.FakePoolDataGeneration
{
    public class FakePoolKeeper : IPoolKeeper
    {
        private readonly List<IPool> _fakePools = new List<IPool>();
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
                AddPoolToKeeper(userName, pool.Name);
                Thread.Sleep(1100);
            }
        }

        public void AddPoolToKeeper(string userName, string poolName)
        {
            _fakePools.Add(new FakePool(4, PoolUpdateTime, userName, poolName, _smartpoolDb));
        }

        //public List<IPool> GetPools()
        //{
        //    return _fakePools;
        //}
    }
}