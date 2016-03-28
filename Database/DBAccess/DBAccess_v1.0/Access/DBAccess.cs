namespace DBAccessV1
{
    public class DBAccess
    {
        public UserAccess UserAccess { get; } = new UserAccess();
        public PoolAccess PoolAccess { get; } = new PoolAccess();
    }
}
