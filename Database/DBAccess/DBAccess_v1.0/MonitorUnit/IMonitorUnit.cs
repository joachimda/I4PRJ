namespace DBAccessV1
{
    public interface IMonitorUnit
    {
        string SerialNumber { get ; set; }
        double Clorine { get; set; }
        string Name { get; set; }
        double Ph { get; set; }
        double Temperature { get; set; }
    }
}