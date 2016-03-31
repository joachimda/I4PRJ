using System;
using Smartpool.Application.Model;

namespace Smartpool.Application.Fake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                AuthenticatorDatabase_InterationTest();
                Console.ReadKey();
            }
        }

        static void AuthenticatorDatabase_InterationTest()
        {
            // get input from user
            Console.WriteLine("Authenticator-Database Integration Test");
            Console.WriteLine("Enter email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();

            // authenticate
            var authenticator = new Authenticator();
            var session = authenticator.Authenticate(email, password);

            // output result
            Console.WriteLine(session.Authenticated() ? "User authenticated!" : "Invalid email or password.");
        }
    }
}
