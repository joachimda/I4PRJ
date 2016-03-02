using System;
using System.Linq;

namespace SPDatabase
{
    public class DatabaseAccessControl
    {
        public SpContext db;

        public DatabaseAccessControl(SpContext dBContext)
        {
            db = dBContext;
        }

        public void AddUserToDatabase(UserEntity userEntity)
        {
            using (db)
            {
                db.UserEntities.Add(userEntity);
                db.SaveChanges();
            }
        }
        
        public void GetQueryForRealNamesInDatabase()
        {
            using (db)
            {
                var query = from realNames in db.RealNames
                    orderby realNames.FirstName
                    select realNames;

                foreach (var realNameItem in query)
                {
                    Console.WriteLine(realNameItem.FirstName);
                }

            }
        }
        /*
        public void DisposeDatabase()
        {
            using (db)
            {
                db.Dispose();
            }
        }



        
        public void AddMonitorUnitToUser(User user, MonitorUnit monitorUnit)
        {
            using (var db = new SpContext())
            {
                
            }

        }
        */
    }
}