using System;

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
                    case "exit":
                        return;
                    #endregion

                    #region Menu: Clear MonitorUnits

                    case "clear mu all":
                        databaseAccessControl.ClearMonitorUnitEntity();
                        break;

                    #endregion

                    case "createsamplepool":
                        Pool pool = new Pool {Depth = 2, Length = 6, PoolName = "Backyard", Width = 3};
                        RealName rnName = new RealName { FirstName = "John", SurName = "Doe" };
                        UserEntity someUserEntity = new UserEntity {Email = "richguy@gmail.com",Password = "password", Name = rnName};
                        databaseAccessControl.AddPoolToUserInDatabase(/*someUserEntity,*/ pool);
                        break;
                }
            }

            #endregion
        }
    }
}


