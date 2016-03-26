namespace DBAccessV1
{
    public class MonitorUnit : IMonitorUnit
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double Ph { get; set; }
        public double Clorine { get; set; }
    }
}