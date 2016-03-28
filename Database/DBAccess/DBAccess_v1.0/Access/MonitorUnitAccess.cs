using System;

namespace DBAccess_v1._0.Access
{
    public class MonitorUnitAccess
    {
        public void AddMonitorUnit(string serialNumber)
        {
            //Compare serial number with database
        }

        public void FindMonitorUnit()
        {
            
        }

        public void FuckAll()
        {
            using (var db = new SmartPoolModelContainer())
            {
                db.Database.ExecuteSqlCommand("DELETE [MonitorUnit]");
            }
        }
    }
}