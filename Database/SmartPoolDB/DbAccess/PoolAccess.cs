namespace DbAccess
{
    public class PoolAccess
    {

        public void DeleteAllPoolData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [PoolSet]");
            }
        }
    }
}