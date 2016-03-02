using System;

namespace SPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseAccessControl databaseAccessControl = new DatabaseAccessControl();
            UserEntity userEntity = new UserEntity();

            userEntity.Name = new RealName {FirstName = "Joachim", MiddleName = "Dam", SurName = "Andersen"};
            databaseAccessControl.AddUserToDatabase(userEntity);

            databaseAccessControl.GetQueryForRealNamesInDatabase();
        }
    }
}
