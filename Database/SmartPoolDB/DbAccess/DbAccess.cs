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

        public void FuckAll()
        {
            UserAccess.DeleteAllData();
            PoolAccess.DeleteAllData();
            MonitorUnitAccess.DeleteAllData();
        }
    }
}
