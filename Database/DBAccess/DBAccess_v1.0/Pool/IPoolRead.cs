namespace DBAccessV1
{
    public interface IPoolRead
    {
        string Name { get; }
        double Temperature { get; }
        double Ph { get; }
        double Clorine { get; }
    }
}