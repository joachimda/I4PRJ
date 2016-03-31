namespace DbAccess
{
    public class MonitorUnitAccess
    {
        public void AddMonitorUnit(Pool pool, string name, string serialNumber, int pin)
        {
            MonitorUnit tempMonitorUnit = new MonitorUnit { PoolId = pool.Id, Name = name, SerialNumber = serialNumber, Pin = pin };
            using (var db = new SmartPoolContext())
            {
                db.MonitorUnitSet.Add(tempMonitorUnit);
                db.SaveChanges();
            }
        }

        public void DeleteAllMonitorUnitData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [MonitorUnitSet]");
            }
        }
    }
}