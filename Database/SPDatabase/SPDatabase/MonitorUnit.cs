using System.ComponentModel.DataAnnotations;

namespace SPDatabase
{
    public class MonitorUnit
    {
        [Key]
        public int MonitorUnitId { get; set; }
        public string SerialNo { get; set; }
    }
}

