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
            Visualizer visualizer = new Visualizer();
            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl();
            visualizer.DrawPossibleCommands();
            
            #region Menu

            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    #region Menu: Add user

                    case "add":
                        User user = new User();
                        user.FullName = visualizer.PromptForNewUser();

                        //Prompt for passwd email, etc goes here.

                        databaseAccessControl.AddUserToDatabase(user);
                        break;

                        #endregion
                }
            }

            #endregion
        }
    }
}
