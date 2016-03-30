namespace DbAccess.Access
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
