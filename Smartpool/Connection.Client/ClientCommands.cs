using System;
using System.Security.RightsManagement;

namespace Client
{
    public class ClientCommands
    {
        private SynchronousSocketClient _client = new SynchronousSocketClient();
        public ClientCommands()
        {
            
        }

        public bool Login(string username, string password)
        {

            return ("Login" == _client.StartClient("Login," + username + "," + password + ",<EOF>"));

        }

        public string GetTemp()
        {
            return _client.StartClient("GetPoolInfo,<EOF>");
        }
    }
}