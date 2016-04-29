using Smartpool;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartpoolDB SmartPoolDB = new SmartpoolDB(new UserAccess(), new PoolAccess());
            //SmartPoolDB.ClearEntireDatabase();
            SmartPoolDB.UserAccess.AddUser("Sir John Traktor", "some@mail.dk", "password123");
            SmartPoolDB.PoolAccess.AddPool(SmartPoolDB.UserAccess.FindUserByEmail("some@email.dk"), "poolname", 5);

            //SmartPoolDB.UserAccess.DeleteAllUsers();
            //SmartPoolDB.UserAccess.AddUser("Joachim Dam Andersen", "jokke@norgaard-andersen.tech", "herropree");
            //SmartPoolDB.UserAccess.AddUser("Bjørn Nørgaaard Sørensen", "bjorn@norgaard-andersen.tech", "helloyou");
            //SmartPoolDB.UserAccess.AddUser("Signe Satan", "signe@hotmail.com", "signespassword");
            //SmartPoolDB.UserAccess.AddUser("Nanna Derps", "derp@gmail.com", "monstersikkerdk");
            //SmartPoolDB.UserAccess.AddUser("Emil Lasse", "emil@lasse.com", "pikpikpik");
            //SmartPoolDB.UserAccess.RemoveUser("jokke@norgaard-andersen.tech");
        }
    }
    /*****************************Don't touch diz!*******************************/
    //var connectionStringCollection = System.Configuration.ConfigurationManager.ConnectionStrings;
    //ConnectionStringSettings connectionStringSetter = new ConnectionStringSettings();
    //connectionStringSetter.ConnectionString = "BjornIsNoob";
    //System.Configuration.ConfigurationManager.ConnectionStrings.Add(connectionStringSetter);
    //Console.WriteLine(connectionStringCollection.Count);
    //var appConfigs = ConfigurationManager.AppSettings;
    //var c = connectionStringCollection.Count;
    //foreach (var key in appConfigs.AllKeys)
    //{
    //    Console.WriteLine("Key: {0} Value: {1}", key, appConfigs[key]);
    //}
}
