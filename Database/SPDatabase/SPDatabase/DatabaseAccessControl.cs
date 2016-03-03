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
                db.UserEntities.Add(userEntity);
                db.SaveChanges();
            }
        }

        public void GetQueryForRealNamesInDatabase()
        {
            using (var db = new SpContext())
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

        public void ClearEntitiesInDatabase()
        {
            using (var db = new SpContext())
            {
                Console.WriteLine("This action wil clear the entire SmartPool user database (yes/no).");

                if (SecurityCheck() == true)
                {
                    db.Database.ExecuteSqlCommand("DELETE [MonitorUnits]");
                    Console.WriteLine("Clearing MonitorUnits...");

                    db.Database.ExecuteSqlCommand("DELETE [Pools]");
                    Console.WriteLine("Clearing pools...");

                    db.Database.ExecuteSqlCommand("DELETE [UserEntities]");
                    Console.WriteLine("Clearing UserEntities...");

                    db.Database.ExecuteSqlCommand("DELETE [RealNames]");
                    Console.WriteLine("Clearing RealNames");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("******************** All tables cleared! *******************");

                    db.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public void ClearMonitorUnitEntity()
        {
            using (var db = new SpContext())
            {
                Console.WriteLine("This action wil clear the entire MonitorUnit entity in the user database (yes/no).");
                if (SecurityCheck() == true)
                {
                    db.Database.ExecuteSqlCommand("DELETE [MonitorUnits]");
                    Console.WriteLine("DELETE [MonitorUnits] run against database: db");
                    Console.WriteLine("MonitorUnits was deletes succesfully");
                }
                else
                {
                    return;
                }
            }
        }

        public void ClearPoolEntity()
        {
            
        }

        private bool SecurityCheck()
        {
            var securityCheck = Console.ReadLine(/* yes/no */);

            if (securityCheck == "yes")
            {
                return true;
            }
            else if (securityCheck == "no")
            {
                Console.WriteLine("Please be more careful. Returning to main menu");
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}