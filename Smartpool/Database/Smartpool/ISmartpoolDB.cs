namespace Smartpool
{
    public interface ISmartpoolDB
    {
        IPoolAccess PoolAccess { get; }
        void ClearEntireDatabase();
    }
}