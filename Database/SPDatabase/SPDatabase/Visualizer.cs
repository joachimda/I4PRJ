using System;
using Microsoft.SqlServer.Server;

namespace SPDatabase
{
    public class Visualizer
    {
        public RealName PromptForNewUser()
        {
            RealName name = new RealName();
            Formatter formatter = new Formatter();

            Console.WriteLine("You are now adding a user to the SmartPool database ");
            Console.WriteLine("Please enter your full name (Use a maximum of 3 names), then press ENTER ");
            string fullName = Console.ReadLine();

            string[] splitNames = {};

            if (fullName != null)
            {
                splitNames = fullName.Split(' ');
                Console.WriteLine("You have input: ");
                foreach (var partOfName in splitNames)
                {
                    Console.Write(" {0}", partOfName);
                }
            }

            return formatter.FormatRealNameInputFromStringArray(splitNames, name);

            /*
            switch (splitNames.Length)
            {
                case 1:
                    name.FirstName = splitNames[0];
                    break;
                case 2:
                    name.FirstName = splitNames[0];
                    name.SurName = splitNames[1];
                    break;
                case 3:
                    name.FirstName = splitNames[0];
                    name.MiddleName = splitNames[1];
                    name.SurName = splitNames[2];
                    break;
            }
            return name;
            */
        }

        public void DrawPossibleCommands()
        {
            Console.WriteLine("      ********** Welcome to SmartPool database management **********");
            Console.WriteLine("");
            Console.WriteLine(String.Format("|****** Task ******|***** Command *****|"));
            Console.WriteLine(String.Format("|Create user       |add                |"));
            Console.WriteLine(String.Format("|Delete all entries|clear              |"));
            Console.WriteLine(String.Format("|Print name query  |qry                |"));
            Console.WriteLine(String.Format("|Quit              |NOT SPECIFIED      |"));
            Console.WriteLine(String.Format("|******************|*******************|"));
        }
    }

    public class Formatter
    {
        public RealName FormatRealNameInputFromStringArray(string[] nameStrings, RealName name)
        {
            switch (nameStrings.Length)
            {
                case 1:
                    name.FirstName = nameStrings[0];
                    break;
                case 2:
                    name.FirstName = nameStrings[0];
                    name.SurName = nameStrings[1];
                    break;
                case 3:
                    name.FirstName = nameStrings[0];
                    name.MiddleName = nameStrings[1];
                    name.SurName = nameStrings[2];
                    break;
            }
            return name;
        }
    }
}