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

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {

                    #region Menu: Add user

                    case "add":
                        UserEntity user = new UserEntity();
                        visualizer.PromptForNewUser();
                        break;

                    #endregion

                    #region Menu: Get query for RealNames in db
                    case "qrn":

                    #endregion

                    #region Menu: Clear

                    case "clear":
                        Console.WriteLine("This action wil clear the entire SmartPool user database (yes/no).");
                        var securityCheck = Console.ReadLine();

                        if (securityCheck == "yes")
                        {
                            databaseAccessControl.ClearEntitiesInDatabase();
                        }
                        else if (securityCheck == "no")
                        {
                            Console.WriteLine("Please be more careful. Returning to main menu");
                        }
                        break;

                    #endregion

                    case "q":
                        break;

                }
            }
            /*
            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl();

            UserEntity userEntity = new UserEntity();
            UserEntity userEntity2 = new UserEntity();


            userEntity.Name = new RealName {FirstName = "Joachim", MiddleName = "Dam", SurName = "Andersen"};
            userEntity2.Name = new RealName {FirstName = "Bjorn", MiddleName = "Norgaard", SurName = "Sorensen"};

            databaseAccessControl.AddUserToDatabase(userEntity);
            databaseAccessControl.AddUserToDatabase(userEntity2);

            databaseAccessControl.GetQueryForRealNamesInDatabase();
            */
            
        }
    }
}


