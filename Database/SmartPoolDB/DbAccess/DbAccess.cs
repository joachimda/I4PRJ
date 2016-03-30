using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public class DbAccess
    {
        public UserAccess UserAccess { get; } = new UserAccess();
        public PoolAccess PoolAccess { get; } = new PoolAccess();
        public MonitorUnitAccess MonitorUnitAccess { get; } = new MonitorUnitAccess();

        public void DeleteAllData()
        {
            UserAccess.DeleteAllUserData();
            PoolAccess.DeleteAllPoolData();
            MonitorUnitAccess.DeleteAllMonitorUnitData();
        }
    }
}
