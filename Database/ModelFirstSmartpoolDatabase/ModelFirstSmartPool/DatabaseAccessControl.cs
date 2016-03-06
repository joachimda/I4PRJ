using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

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


    public class Creator
    {
        public User AssembleUser()
        {
            User user = new User();
            user.FullName = NewUserPromptForFullName();
            user.Password = NewUserPromptForPassword();
            user.Email = NewUserPromptForEmail();
            return user;
        }

        private string NewUserPromptForEmail()
        {
            Console.WriteLine("Please write your email address formatted as username@host.domain ");

            //We should use built in email attribute
            return Console.ReadLine();

        } 

        private string NewUserPromptForPassword()
        {
            Console.WriteLine("Please enter your desired password");
            var password = Console.ReadLine();
            return password;
        }

        
        private FullName NewUserPromptForFullName()
        {
            FullName name = new FullName();
            Formatter formatter = new Formatter();
            bool validNameEntered = false;

            Console.WriteLine("You are now adding a user to the SmartPool database ");
            Console.WriteLine("Please enter your full name (Use a maximum of 3 names), then press ENTER ");

            string[] splitNames = { };

            while (!validNameEntered)
            {
                string fullName = Console.ReadLine();

                if (fullName != null && fullName.Length > 3)
                {
                    splitNames = fullName.Split(' ');
                    Console.WriteLine("You have input: ");
                    foreach (var partOfName in splitNames)
                    {
                        Console.Write(" {0}", partOfName);
                    }
                    validNameEntered = true;
                }

                else
                {
                    Console.WriteLine("Please write a valid name ");
                }
            }

            return formatter.FormatRealNameInputFromStringArray(splitNames, name);

        }
    }
}