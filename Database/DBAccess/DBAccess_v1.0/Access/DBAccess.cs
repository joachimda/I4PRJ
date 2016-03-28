using DBAccessV1;

namespace DBAccess_v1._0.Access
{
    public class DbAccess
    {
        public UserAccess UserAccess { get; } = new UserAccess();
        public PoolAccess PoolAccess { get; } = new PoolAccess();
        public MonitorUnitAccess MonitorUnitAccess { get; } = new MonitorUnitAccess();

        public void FuckAll()
        {
            UserAccess.FuckAll();
            PoolAccess.FuckAll();
            MonitorUnitAccess.FuckAll();
        }
    }

}
