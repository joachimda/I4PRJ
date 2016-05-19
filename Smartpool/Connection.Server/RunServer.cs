using System;
using System.Globalization;
using System.Threading;
using Smartpool.Connection.Server.FakePoolDataGeneration;

namespace Smartpool.Connection.Server
{
    class RunServer
    {
        public static int Main(String[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Console.WriteLine(CultureInfo.CurrentCulture);
            Console.WriteLine("Server starting. Please wait and ensure you are connected to VPN");
            var db = new SmartpoolDB(new DataAccess(new PoolAccess(new UserAccess())));
            db.DataAccess.DeleteAllData();
            var socketListener = new AsynchronousSocketListener(new ResponseManager(db));
            socketListener.StartListening();
            return 0;
        }
    }
}
