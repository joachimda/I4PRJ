using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UserContext())
            {
                Console.WriteLine("Type your username");
                var name = Console.ReadLine();
                Console.WriteLine("Type your password");
                var passwd = Console.ReadLine();
                Console.WriteLine("Type your email");
                var email = Console.ReadLine();

                User user = new User {Name = name,Password = passwd, Email = email};

                db.Users.Add(user);
                db.SaveChanges();

                var query = from u in db.Users
                    orderby u.Name
                    select u;
                foreach (var userItem in query)
                {
                    Console.WriteLine(userItem.Name);
                }
            }
        }
    }
}
