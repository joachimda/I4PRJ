namespace DBAccessV1
{
    public interface IPoolRead
    {
        string Name { get; }
        int Temperature { get; }
        double Ph { get; }
        double Clorine { get; }
    }
}