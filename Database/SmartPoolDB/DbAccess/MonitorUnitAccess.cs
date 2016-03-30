namespace DbAccess
{
    public class MonitorUnitAccess
    {
        public void AddMonitorUnit(Pool pool, string name, string serialNumber)
        {
            MonitorUnit tempMonitorUnit = new MonitorUnit(); { /* Name = name, Length = length, Width = width, Depth = depth, UserId = owner.Id*/ };

            using (var db = new SmartPoolContext())
            {
                db.PoolSet.Add(tempPool);
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