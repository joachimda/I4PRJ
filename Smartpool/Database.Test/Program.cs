using System;
using System.Net.Mail;
using System.Threading;
using Smartpool;
using Smartpool.DataAccess;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartpoolDB SmartPoolDB = new SmartpoolDB(new PoolAccess(new UserAccess()));

            IWriteDataAccess dataAccess = new DataAccess();
            dataAccess.PoolAccess = SmartPoolDB.PoolAccess;
            dataAccess.DeleteAllData();

            SmartPoolDB.ClearEntireDatabase();
            
            SmartPoolDB.UserAccess.AddUser("Sir john derp", "email", "pass");
            SmartPoolDB.PoolAccess.AddPool("email", "baghave", 9);

            dataAccess.CreateDataEntry("email", "baghave", 5, 9, 3, 10);
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
