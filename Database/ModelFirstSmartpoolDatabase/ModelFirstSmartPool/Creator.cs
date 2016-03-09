using System;
using System.Globalization;
using System.Security.Authentication.ExtendedProtection;

namespace ModelFirstSmartPool
{
    public class Creator
    {
        private readonly DatabaseAccessControl _databaseAccessControl = new DatabaseAccessControl();

        public User MandatoryAssemblyOfUser() //Template method
        {
            User user = new User
            {
                FullName = NewUserPromptForFullName(),
                Password = NewUserPromptForPassword(),
                Email = NewUserPromptForEmail()
            };

            //For test!
            user.Pools.Add(MandatoryAssemblyOfPool(user));

            
            //_databaseAccessControl.AddUserToDatabase(user);

            return user;
        }

        public Pool MandatoryAssemblyOfPool(User user) //Template method
        {
            Pool pool = new Pool {User = user};
            //This is assigning the pool to the user??
            Console.WriteLine("You are now creating a pool system, and we need some information to create your pool..");

            pool.Name = NewPoolPromptForPoolName();
            pool.PoolDimension = NewPoolPromptForPoolDimensions(pool);
            //pool.UserUserId = user.UserId; //Is this the assignment thingy?
            return pool;
        }

        private static PoolDimensions NewPoolPromptForPoolDimensions(Pool pool)
        {
            PoolDimensions poolDimensions = new PoolDimensions {Pool = pool};

            Console.WriteLine("How deep is your pool?");
            poolDimensions.Depth = Console.Read();

            Console.WriteLine("How long is your pool?");
            poolDimensions.Length = Console.Read();

            Console.WriteLine("How wide is your pool?");
            poolDimensions.Width = Console.Read();

            return poolDimensions;
        }

        private static string NewPoolPromptForPoolName()
        {
            Console.WriteLine("What would you like to call your pool? eg. Frontyard or mypool ");
            return Console.ReadLine();
        }

        private static string NewUserPromptForEmail()
        {
            Console.WriteLine("Please write your email address formatted as username@host.domain ");

            //We should use built in email attribute

            return Console.ReadLine();

        } 

        private static string NewUserPromptForPassword()
        {
            Console.WriteLine("Please enter your desired password");
            var password = Console.ReadLine();
            return password;
        }
        
        private static FullName NewUserPromptForFullName()
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