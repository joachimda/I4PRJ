//========================================================================
// FILENAME :   PoolLoader.cs
// DESCR.   :   Model for loading and parsing pool names
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class PoolLoader
    {
        private Session _session = Session.SharedSession;

        public void ReloadPools(IClientMessager clientMessaget)
        {
            var poolRequest = new GetPoolDataRequestMsg(_session.UserName, _session.TokenString, true);
            var response = clientMessaget.SendMessage(poolRequest);
            var poolResponse = response as GetPoolDataResponseMsg;

            if (poolResponse != null)
            {
                _session.Pools = poolResponse.AllPoolNamesListTuple;
            }
        }

        public int IndexForPoolName(string name)
        {
            for (int i = 0; i < _session.Pools.Count; i++)
            {
                if (_session.Pools[i].Item1 == name) return i;
            }
            return 0;
        }

        public bool PoolsAreAvailable()
        {
            return _session.Pools.Count > 0;
        }
    }
}
