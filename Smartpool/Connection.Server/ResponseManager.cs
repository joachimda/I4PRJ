using Smartpool;
using Smartpool.Factories;

namespace ServerTest
{
    public class ResponseManager : IResponseManager
    {
        public string Respond(string content)
        {
            SmartpoolDB _smartpoolDb = new SmartpoolDB(new StdAccessFactory());

            var receivedStrings = content.Split(',');
            
            switch (receivedStrings[0])
            {
                case "Login":
                    
                    if (_smartpoolDb.UserAccess.ValidatePassword(receivedStrings[1], receivedStrings[2]))
                        return "Login";
                    else
                    {
                        return "Login failed";
                    }
                case "GetPoolInfo":
                    return "Temperature in pool is 25 degrees";
                default:
                    return "The server did not recognize your request";
            }
        }
    }
}