namespace Smartpool.Connection.Model
{
    public enum FakeSensorEnum
    {
        Temperature = 0, // Leisure waters	28ºC to 30ºC http://pwtag.org/technicalnotes/pool-temperatures/
        Chlorine = 1, // 0.5-1.5 ppm (mg/l) http://www.pahlen.com/users-guide/ph-and-chlorine
        Ph = 2, // The guideline pH figure is 7.2 – 7.6 http://www.pahlen.com/users-guide/ph-and-chlorine
        Humidity = 3 // Maintain Relative Humidity between 50% & 60% RH. Do not go below 50% http://www.serescodehumidifiers.com/engineers/indoor-pool-design/Attic/comfort-health-safety.html
    }
}