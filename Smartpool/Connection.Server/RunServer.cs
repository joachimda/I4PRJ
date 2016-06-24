using System;
using System.Globalization;
using System.Threading;

namespace Smartpool.Connection.Server
{
    class RunServer
    {
        public static int Main(String[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Console.WriteLine("Server starting. Please wait and ensure you are connected to VPN");

            IUserAccess userAccess = new UserAccess();
            IPoolAccess poolAccess = new PoolAccess(userAccess);
            IDataAccess dataAccess = new DataAccess(poolAccess);
            poolAccess.DataAccess = dataAccess;

            var db = new SmartpoolDB(dataAccess);
            var socketListener = new AsynchronousSocketListener(new ResponseManager(db));
            socketListener.StartListening();
            return 0;
        }
    }
}
