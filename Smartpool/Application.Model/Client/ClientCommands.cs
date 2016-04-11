//========================================================================
// FILENAME :   ClientCommands.cs
// DESCR.   :   Interface for authenticators
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  JW      Initial version
// 1.1  LP      Replaced client with an interface
//========================================================================

// ReSharper disable once CheckNamespace

using Smartpool.Connection.Model;

namespace Smartpool.Application.Model
{
    public class ClientCommands
    {
        private readonly IClientMessager _clientMessager;

        public ClientCommands(IClientMessager clientMessager)
        {
            _clientMessager = clientMessager;
        }

        public bool Login(string username, string password)
        {
            // Client returns "Login" if the password and username was accepted
            return ("Login" == _clientMessager.SendMessage(new LoginMsg(username,password)));
        }

        public string GetTemp()
        {
            return _clientMessager.SendMessage(new Message());
        }

        public PoolInfo GetPoolInfo(string username, UserSessionToken userSessionToken)
        {
            var returnedStrings = _clientMessager.SendMessage(new Message()).Split(',');
            
            double temp = 0;
            double.TryParse(returnedStrings[0], out temp);
            double clor = 0;
            double.TryParse(returnedStrings[1], out clor);

            return new PoolInfo(temp, clor);
        }
    }
}