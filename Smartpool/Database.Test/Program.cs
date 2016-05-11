using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using Smartpool;

namespace Database.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartpoolDB SmartPoolDB = new SmartpoolDB(new DataAccess(new PoolAccess(new UserAccess())));
            IDataAccess dataAccess = new DataAccess(new PoolAccess(new UserAccess()));
            dataAccess.DeleteAllData();
            SmartPoolDB.ClearEntireDatabase();

            SmartPoolDB.UserAccess.AddUser("Sir john derp", "email", "pass");
            SmartPoolDB.PoolAccess.AddPool("email", "baghave", 9);

            for (int i = 0; i < 10; i++)
            {
                dataAccess.CreateDataEntry("email", "baghave", 5+i, 9+1, 3+i, 10+i);
                Thread.Sleep(1500);
            }


            List<Tuple<string, double>> chlorineTuples = dataAccess.GetChlorineValues("email", "baghave", "11/05/2016 11:47:51", "11/05/2016 12:20:45");
            foreach (var chlorineTuple in chlorineTuples)
            {
                Console.WriteLine(chlorineTuple.Item1 + chlorineTuple.Item2);
            }


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
