using System;
using System.Linq;

namespace SPDatabase
{
    public class DatabaseAccessControl
    {
        public void AddUserToDatabase(UserEntity userEntity)
        {
            using (var db = new SpContext())
            {
                db.UsersInDatabase.Add(userEntity);
            }
        }

        public void GetQueryForRealNamesInDatabase()
        {
            using (var db = new SpContext())
            {
                var query = from realNames in db.UsersInDatabase
                    orderby realNames.Name
                    select realNames;

                foreach (var realNameItem in query)
                {
                    Console.WriteLine(realNameItem.Name);
                }

            }
        }

        /*
        public void AddMonitorUnitToUser(User user, MonitorUnit monitorUnit)
        {
            using (var db = new SpContext())
            {
                
            }

        }
        */
    }
}