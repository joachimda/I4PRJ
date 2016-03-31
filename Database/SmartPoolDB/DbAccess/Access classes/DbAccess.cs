namespace DbAccess
{
    public class DbAccess
    {
        public UserAccess UserAccess { get; } = new UserAccess();
        public PoolAccess PoolAccess { get; } = new PoolAccess();
        public MonitorUnitAccess MonitorUnitAccess { get; } = new MonitorUnitAccess();

        public void DeleteAllData()
        {
            MonitorUnitAccess.DeleteAllMonitorUnitData();
            PoolAccess.DeleteAllPoolData();
            UserAccess.DeleteAllUserData();
        }
    }
}
