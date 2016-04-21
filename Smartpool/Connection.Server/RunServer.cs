using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartpool.Connection.Server
{
    class RunServer
    {
        public static int Main(String[] args)
        {
            var socketListener = new AsynchronousSocketListener();
            socketListener.StartListening();
            return 0;
        }
    }
}
