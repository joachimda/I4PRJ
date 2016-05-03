using System;

namespace Smartpool.Connection.Server
{
    class RunServer
    {
        public static int Main(String[] args)
        {
            var socketListener = new AsynchronousSocketListener(new ResponseManager(new SmartpoolDB(new PoolAccess(new UserAccess()))));
            socketListener.StartListening();
            return 0;
        }
    }
}
