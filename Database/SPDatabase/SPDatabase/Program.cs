using System;

namespace SPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SpContext();
            
            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl(db);

            UserEntity userEntity = new UserEntity();
            UserEntity userEntity2 = new UserEntity();


            userEntity.Name = new RealName {FirstName = "Joachim", MiddleName = "Dam", SurName = "Andersen"};
            userEntity2.Name = new RealName {FirstName = "Bjorn", MiddleName = "Norgaard", SurName = "Sorensen"};

            databaseAccessControl.AddUserToDatabase(userEntity);
            databaseAccessControl.AddUserToDatabase(userEntity2);

            databaseAccessControl.GetQueryForRealNamesInDatabase();
            

            
        }
    }
}
