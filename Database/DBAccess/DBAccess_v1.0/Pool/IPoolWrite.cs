namespace DBAccessV1
{
    public interface IPoolWrite
    {
        string Name { get; set; }
        double Temperature { get; }
        double Ph { get; }
        double Clorine { get; }
    }
}