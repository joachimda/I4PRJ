using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstSmartPool
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SmartPoolContext())
            {

            }
        }
    }

    public class DatabaseAccessControl
    {
        public void AddUserToDatabase(User user)
        {
            using (var db = new SmartPoolContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void ClearAllEntitiesInDatabase()
        {
            using (var db = new SmartPoolContext())
            {
                Console.WriteLine("This action wil clear the entire SmartPool user database (yes/no).");

                if (SecurityCheck() == true)
                {

                    //These commands need to be parameterized
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

        public bool SecurityCheck()
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
