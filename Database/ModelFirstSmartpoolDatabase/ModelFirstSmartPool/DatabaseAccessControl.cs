using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace ModelFirstSmartPool
{
    public class DatabaseAccessControl : DbContext
    {
        // Made an override to check for exceptions thx to stackoverflow :)
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var errMsg = exception.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullMsg = string.Join("; ", errMsg);

                var exceptionMsg = string.Concat(exception.Message, "The validation errors are: ", fullMsg);
                throw new DbEntityValidationException(exceptionMsg, exception.EntityValidationErrors);
            }
        }

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
                    Console.WriteLine("************************************************************");

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

            switch (securityCheck)
            {
                case "yes":
                    return true;
                case "no":
                    Console.WriteLine("Please be more careful. Returning to main menu");
                    return false;
                default:
                    return false;
            }
        }

        public void ClearMonitorUnitEntity()
        {
            using (var db = new SmartPoolContext())
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

    }
}