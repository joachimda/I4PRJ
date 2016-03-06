using System;

namespace ModelFirstSmartPool
{
    public class Creator
    {
        public User AssembleUser() //Template method
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