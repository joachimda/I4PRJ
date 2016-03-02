using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;

namespace SPDatabase
{
    public class UserInDatabase
    {
        public int UserId { get; set; }
        public RealName Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int NumberOfRegisteredMonitorUnits { get; set; }
        public virtual List<MonitorUnit> RegisteredMonitorUnits { get; set; }
        //public virtual List<Pool> RegisteredPools { get; set; }
    }
}