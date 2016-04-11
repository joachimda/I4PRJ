//========================================================================
// FILENAME :   ClientCommands.cs
// DESCR.   :   Interface for authenticators
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  JW      Initial version
// 1.1  LP      Replaced client with an interface
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Model
{
    public class ClientCommands
    {
        private readonly IClient _client;

        public ClientCommands(IClient client)
        {
            _client = client;
        }

        public bool Login(string username, string password)
        {
            // Client returns "Login" if the password and username was accepted
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
}