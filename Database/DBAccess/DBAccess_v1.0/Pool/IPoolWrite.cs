namespace DBAccessV1
{
    public interface IPoolWrite
    {
        string Name { get; set; }
        int Temperature { get; set; }
        double Ph { get; set; }
        double Clorine { get; set; }
    }
}