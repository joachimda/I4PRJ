namespace DBAccess_v1._0.Access
{
    public class PoolAccess
    {
        public void AddPool(string name)
        {
            // make temp pool
            //Pool temPool = new Pool(name);

            // add pool to db
        }

        public Pool FindPool(string name)
        {
            // find pool

            return new Pool();
        }

        public void FuckAll()
        {
            using (var db = new SmartPoolModelContainer())
            {
                db.Database.ExecuteSqlCommand("DELETE [Pool]");
            }
        }
    }
}