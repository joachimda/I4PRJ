using System;

namespace ModelFirstSmartPool
{
    public class Visualizer
    {
      /*  public FullName PromptForNewUser()
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
        */

        public void DrawPossibleCommands()
        {
            Console.WriteLine("      ********** Welcome to SmartPool database management **********");
            Console.WriteLine("");
            Console.WriteLine(String.Format("|****** Task ******|***** Command *****|"));
            Console.WriteLine(String.Format("|Create user       |add                |"));
            Console.WriteLine(String.Format("|Delete all entries|clear              |"));
            Console.WriteLine(String.Format("|Print name query  |qry                |"));
            Console.WriteLine(String.Format("|Exit program      |exit               |"));
            Console.WriteLine(String.Format("|******************|*******************|"));
        }
    }
}