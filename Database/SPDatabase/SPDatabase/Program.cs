using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl();
            UserInDatabase user1 = new UserInDatabase();

            user1.Name = new RealName {FirstName = "Joachim", MiddleName = "Dam", SurName = "Andersen"};
            databaseAccessControl.AddUserToDatabase(user1);

            databaseAccessControl.GetQueryForRealNamesInDatabase();

            /*
            using (var db = new SpContext())
            {

                Console.WriteLine("Type your first name");
                var fName = Console.ReadLine();
                Console.WriteLine("Type your middlename");
                var mName = Console.ReadLine();
                Console.WriteLine("Type your surname");
                var sName = Console.ReadLine();
                Console.WriteLine("Type your password");
                var passwd = Console.ReadLine();
                Console.WriteLine("Type your email");
                var email = Console.ReadLine();
                
                UserInDatabase userInDatabase = new UserInDatabase
                {
                    Name = new RealName {FirstName = fName, MiddleName = mName, SurName = sName},
                    Email = email
                };

                Console.WriteLine("User has been created");

                db.Users.Add(userInDatabase);
                db.SaveChanges();
                

                Console.WriteLine("Display userIds in DB:  ");

                var query = from u in db.Users
                    orderby u.UserId
                    select u;
                foreach (var userItem in query)
                {
                    Console.WriteLine(userItem.UserId);
                }

                Console.WriteLine("Display Passwds in DB:  ");

                var query2 = from p in db.Users
                            orderby p.Password
                            select p;
                foreach (var userItem in query2)
                {
                    Console.WriteLine(userItem.Password);
                }
                



            }
            */
        }
    }
}
