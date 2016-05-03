using Smartpool;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartpoolDB SmartPoolDB = new SmartpoolDB(new UserAccess(), new PoolAccess());
            SmartPoolDB.ClearEntireDatabase();

            SmartPoolDB.UserAccess.AddUser("Sir Derp Hansen", "email@hensen.dk", "pass124");
            SmartPoolDB.UserAccess.AddUser("Miss Herine sen", "sen@her.com", "pass");
            SmartPoolDB.UserAccess.AddUser("Duke Dennis Fucktarrt", "duck@import.dk", "asljh");

            SmartPoolDB.PoolAccess.AddPool(SmartPoolDB.UserAccess.FindUserByEmail("email@hensen.dk"), "Sir Derp's Pool", 20);
            SmartPoolDB.PoolAccess.AddPool(SmartPoolDB.UserAccess.FindUserByEmail("sen@her.com"), "Miss's Pool", 11);
            SmartPoolDB.PoolAccess.AddPool(SmartPoolDB.UserAccess.FindUserByEmail("duck@import.dk"), "Duke's Pool", 5);
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
