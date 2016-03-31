namespace DbAccess.Access
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
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [MonitorUnit]");
            }
        }
    }
}