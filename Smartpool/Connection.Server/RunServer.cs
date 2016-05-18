using System;

namespace Smartpool.Connection.Server
{
    class RunServer
    {
        public static int Main(String[] args)
        {

            Console.WriteLine("Server starting. Please wait and ensure you are connected to VPN");
            var socketListener = new AsynchronousSocketListener(new ResponseManager(new SmartpoolDB(new DataAccess(new PoolAccess(new UserAccess())))));
            socketListener.StartListening();
            return 0;
        }
    }
}
