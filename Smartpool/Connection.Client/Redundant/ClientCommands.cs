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
            return _client.StartClient("GetTemp,<EOF>");
        }

        public PoolInfo GetPoolInfo(string username, UserSessionToken userSessionToken)
        {
            var returnedStrings = _client.StartClient("GetPoolInfo,<EOF>").Split(',');
            
            double temp = 0;
            double.TryParse(returnedStrings[0], out temp);
            double clor = 0;
            double.TryParse(returnedStrings[1], out clor);

            return new PoolInfo(temp, clor);
        }
    }

    public class PoolInfo
    {
        public PoolInfo(double temperature, double clorine)
        {
            Temperature = temperature;
            Clorine = clorine;
        }
        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        private double _chlorine;

        public double Clorine
        {
            get { return _chlorine; }
            set { _chlorine = value; }
        }

    }

    public class UserSessionToken
    {
        
    }
}