namespace DbAccess
{
    public class PoolAccess
    {

        public void AddPool(string name, double length, double width, double depth)
        {
            Pool tempPool = new Pool { Name = name, Length = length, Width = width, Depth = depth};

            using (var db = new SmartPoolContext())
            {
                db.PoolSet.Add(tempPool);
                db.SaveChanges();
            }
        }

        public void DeleteAllPoolData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [PoolSet]");
            }
        }
    }
}