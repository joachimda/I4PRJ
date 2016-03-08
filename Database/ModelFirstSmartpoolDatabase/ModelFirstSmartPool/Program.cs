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
            Creator creator = new Creator();
            PrintQueries printer = new PrintQueries();

            visualizer.DrawPossibleCommands();
            
            #region Menu

            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    #region Menu: Add user

                    case "add":
                        databaseAccessControl.AddUserToDatabase(creator.MandatoryAssemblyOfUser());
                        break;
                    #endregion

                    #region Menu: Query for all users in database

                    case "qry":
                        printer.GetAllUsers();
                        break;

                        #endregion
                }
            }

            #endregion
        }
    }
}
