﻿using System;

namespace SPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl();
            Visualizer visualizer = new Visualizer();
            visualizer.DrawPossibleCommands();

            #region Menu

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {

                    #region Menu: Add user

                    case "add":
                        UserEntity user = new UserEntity();
                        user.Name = visualizer.PromptForNewUser();

                        //Prompt for password email etc goes here..

                        databaseAccessControl.AddUserToDatabase(user);
                        break;

                    #endregion

                    #region Menu: Get query for RealNames in db
                    case "qry":
                        databaseAccessControl.GetQueryForRealNamesInDatabase();
                        break;

                    #endregion

                    #region Menu: Clear

                    case "clear":
                        databaseAccessControl.ClearEntitiesInDatabase();
                        break;
                    #endregion

                    #region Menu: Quit
                    case "q":
                        break;
                    #endregion

                    #region Menu: Clear MonitorUnits

                    case "clear mu all":
                        databaseAccessControl.ClearMonitorUnitEntity();
                        break;

                        #endregion

                }
            }

            #endregion
        }
    }
}


