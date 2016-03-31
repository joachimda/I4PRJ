using System.Collections.Generic;

namespace DbAccess
{
    public class PoolAccess
    {

        public void AddPool(User owner, string name, double length, double width, double depth)
        {
            Pool tempPool = new Pool { Name = name, Length = length, Width = width, Depth = depth, UserId = owner.Id};

            using (var db = new SmartPoolContext())
            {
                db.PoolSet.Add(tempPool);
                db.SaveChanges();
            }
        }

       // public List<Pool> Find 

        public void DeleteAllPoolData()
        {
            using (var db = new SmartPoolContext())
            {
                db.Database.ExecuteSqlCommand("DELETE [PoolSet]");
            }
        }
    }
}